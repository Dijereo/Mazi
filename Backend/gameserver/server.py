import secrets
import socket
import threading


META_LENGTH = 8


class AuthConnection:
	connectionid = 0

	def __init__(self, authsocket, address, serverctx):
		self.conn_id = self.next_id()
		self.authsocket = authsocket
		self.address = address
		self.connected = True
		self.thread = threading.Thread(target=self.handle)
		self.serverctx = serverctx
		self.key = secrets.token_urlsafe(32)
		self.state = 0

	def start(self):
		self.thread.start()

	def handle(self):
		while self.connected:
			msg = self.recv()
			if msg is not None:
				self.interpret(msg)
		self.authsocket.close()
		self.serverctx.disconnect(self)

	def interpret(self, msg):
		if self.state == 0:
			self.username = msg
			self.state = 1
			self.send(self.key)

	def recv(self):
		meta_len = self.authsocket.recv(META_LENGTH).decode('utf-8')
		if not meta_len:
			return None
		msg_length = int(meta_len)
		msg = self.authsocket.recv(msg_length).decode('utf-8')
		return msg

	def send(self, msg):
		message = msg.encode('utf-8')
		msg_length = str(len(message)).ljust(META_LENGTH).encode('utf-8')
		self.authsocket.send(msg_length)
		self.authsocket.send(message)

	def __eq__(self, other):
		return type(other) is type(self) and self.conn_id == other.conn_id

	def __hash__(self):
		return 31 * hash('AuthConnection') + hash(self.conn_id)

	@classmethod
	def next_id(cls):
		val = cls.connectionid
		cls.connectionid += 1
		return val


class ServerContext:
	def __init__(self, port):
		self.server = socket.socket()
		self.port = port
		self.ip = socket.gethostbyname(socket.gethostname()) # 192.168.0.2
		self.conns = set()

	def start(self):
		self.server.bind((self.ip, self.port))
		self.server.listen()
		while True:
			connsocket, address = self.server.accept()
			newconn = AuthConnection(connsocket, address, self)
			self.conns.add(newconn)
			newconn.start()

	def disconnect(self, client):
		self.conns.remove(client)


if __name__ == '__main__':
	authlistener = ServerContext(9010)
	authlistener.start()
