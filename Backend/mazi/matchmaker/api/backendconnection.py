import socket

from ..gameserver.socketwrapper import BaseConnection

SERVER = '192.168.0.2'
PORT = 9009
META_LENGTH = 8


class BackendConnection(BaseConnection):
	def __init__(self, username):
		super().__init__(socket.socket())
		self.username = username
		self.connsocket.connect((SERVER, PORT))

	def getauthtoken(self):
		self.send(self.username)
		authtoken = self.recv()
		self.connsocket.close()
		return authtoken
