from collections import deque
import secrets
import socket
import threading
import time

from socketwrapper import *


class AuthListener(BaseListener):
	def __init__(self, ip, port):
		super().__init__(ip, port)
		self.authorized = {}

	def createconnection(self, client, address):
		return AuthConnection(client, address, self)

	def authorize(self, authtoken, username):
		self.authorized[authtoken] = username

	def popauthorized(self, authtoken):
		return self.authorized.pop(authtoken, None)


class AuthConnection(BaseServerConnection):
	def __init__(self, authsocket, address, listener):
		super().__init__(authsocket, address, listener)
		self.authkey = secrets.token_urlsafe(32)

	def handle(self):
		username = self.recv()
		self.listener.authorize(self.authkey, username)
		self.send(self.authkey)
		super().handle()


class QueueListener(BaseListener):
	def __init__(self, ip, port, authlistener, playerqueue):
		super().__init__(ip, port)
		self.queue = playerqueue
		self.authlistener = authlistener

	def createconnection(self, client, address):
		return QueueConnection(client, address, self)

	def authenticate(self, authtoken, connection):
		username = self.authlistener.popauthorized(authtoken)
		if username is not None:
			self.queue.addclient(authtoken, username, connection)


class QueueConnection(BaseServerConnection):
	def __init__(self, clientsocket, address, listener):
		super().__init__(clientsocket, address, listener)
		self.matchfound = False
		self.gametoken = None

	def handle(self):
		authtoken = self.recv()
		self.listener.authenticate(authtoken, self)
		while not self.matchfound:
			time.sleep(3)
		self.send(self.gametoken)
		super().handle()

	def findmatch(self, gametoken):
		self.gametoken = gametoken
		self.matchfound = True


class PlayerQueue:
	def __init__(self, matchlistener):
		self.queue = deque()
		self.matchlistener = matchlistener
		self.thread = threading.Thread(target=self.makematch)

	def start(self):
		self.thread.start()

	def makematch(self):
		while True:
			if len(self.queue) >= 2:
				authtoken1, username1, connection1 = self.queue.popleft()
				authtoken2, username2, connection2 = self.queue.popleft()
				gametoken = secrets.token_urlsafe(32)
				match = Match(gametoken, authtoken1, username1, authtoken2, username2)
				self.matchlistener.addmatch(match)
				connection1.findmatch(gametoken)
				connection2.findmatch(gametoken)
			time.sleep(5)

	def addclient(self, authtoken, username, connection):
		self.queue.append((authtoken, username, connection))


class MatchListener(BaseListener):
	def __init__(self, ip, port):
		super().__init__(ip, port)
		self.matches = {}

	def createconnection(self, client, address):
		return MatchConnection(client, address, self)

	def addmatch(self, match):
		self.matches[match.gametoken] = match

	def startplayer(self, gametoken, authtoken, connection):
		match = self.matches.get(gametoken, None)
		if match is not None:
			match.startplayer(authtoken, connection)


class MatchConnection(BaseServerConnection):
	def __init__(self, clientsocket, address, listener):
		super().__init__(clientsocket, address, listener)
		self.matchinitialized = False
		self.receiving = False
		self.connected = True

	def handle(self):
		gametoken = self.recv()
		authtoken = self.recv()
		self.listener.startplayer(gametoken, authtoken, self)
		while not self.matchinitialized:
			time.sleep(1)
		self.send('INITIALIZE')
		self.send(self.gamedata)
		self.connsocket.settimeout(600)
		while self.connected:
			if self.receiving:
				try:
					data = self.recv()
				except socket.timeout as err:
					self.match.command('TIMEOUT', self)
				else:
					self.match.command(data, self)
			else:
				time.sleep(1)
		super().handle()

	def initializematch(self, match, gamedata):
		self.match = match
		self.gamedata = gamedata
		self.matchinitialized = True


class Match:
	def __init__(self, gametoken, authtoken1, username1, authtoken2, username2):
		self.gametoken = gametoken
		self.authtoken1 = authtoken1
		self.username1 = username1
		self.connection1 = None
		self.authtoken2 = authtoken2
		self.username2 = username2
		self.connection2 = None
		self.turn = 1

	def command(self, data, connection):
		otherconn = self.connection2 if connection is self.connection1 else self.connection1
		if data == 'WIN':
			otherconn.send('LOSE')
			connection.connected = False
			otherconn.connected = False
		elif data == 'ENDTURN':
			otherconn.send('PLAY')
			otherconn.receiving = True
			connection.receiving = False
		else:
			otherconn.send(data)


	def startplayer(self, authtoken, connection):
		if self.authtoken1 == authtoken and self.connection1 is None:
			self.connection1 = connection
		elif self.authtoken2 == authtoken and self.connection2 is None:
			self.connection2 = connection
		if self.connection1 is not None and self.connection2 is not None:
			self.connection1.initializematch(self, self.username2)
			self.connection2.initializematch(self, self.username1)
			self.connection1.send('PLAY');
			self.connection1.receiving = True


def main():
	ip = '192.168.0.2'
	authlistener = AuthListener(ip, 9009)
	matchlistener = MatchListener(ip, 9011)
	playerqueue = PlayerQueue(matchlistener)
	queuelistener = QueueListener(ip, 9010, authlistener, playerqueue)
	authlistener.start()
	matchlistener.start()
	queuelistener.start()
	playerqueue.start()


if __name__ == '__main__':
	main()
