import secrets
import socket
import threading


META_LENGTH = 8


class BaseListener:
	def __init__(self, ip, port):
		self.listener = socket.socket()
		self.port = port
		self.ip = ip
		self.connections = set()
		self.thread = threading.Thread(target=self.listen)

	def start(self):
		self.thread.start()

	def listen(self):
		self.listener.bind((self.ip, self.port))
		self.listener.listen()
		while True:
			client, address = self.listener.accept()
			connection = self.createconnection(client, address)
			self.connections.add(connection)
			connection.start()

	def createconnection(self, client, address):
		raise NotImplementedError()

	def disconnect(self, connection):
		self.connections.remove(connection)


class BaseConnection:
	def __init__(self, connsocket):
		self.connsocket = connsocket

	def recv(self):
		msglength = self.connsocket.recv(META_LENGTH).decode('utf-8')
		while not msglength:
			msglength = self.connsocket.recv(META_LENGTH).decode('utf-8')
		return self.connsocket.recv(int(msglength)).decode('utf-8')

	def send(self, msg):
		message = msg.encode('utf-8')
		msglength = str(len(message)).ljust(META_LENGTH).encode('utf-8')
		self.connsocket.send(msglength)
		self.connsocket.send(message)


class BaseServerConnection(BaseConnection):
	def __init__(self, connsocket, address, listener):
		super().__init__(connsocket)
		self.connectionid = secrets.token_urlsafe(32)
		self.address = address
		self.listener = listener
		self.thread = threading.Thread(target=self.handle)

	def start(self):
		self.thread.start()

	def handle(self):
		self.connsocket.close()
		self.listener.disconnect(self)

	def __eq__(self, other):
		return type(other) is type(self) and self.connectionid == other.connectionid

	def __hash__(self):
		return 31 * hash('Connection') + hash(self.connectionid)
