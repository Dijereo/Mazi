import socket
import threading


META_LENGTH = 8
HANDSHAKE_MESSAGE = 'HELLO'
DISCONNECT_MESSAGE = 'DISCONNECT'


class ClientConnection:
	connectionid = 0

	def __init__(self, clientsocket, address, server):
		self.conn_id = self.get_and_set_next_id()
		self.client = clientsocket
		self.address = address
		self.connected = True
		self.thread = threading.Thread(target=self.handle_client)
		self.server = server

	def start_and_run(self):
		self.thread.start()

	def handle_client(self):
		while self.connected:
			header = self.client.recv(META_LENGTH).decode('utf-8')
			if not header:
				continue
			msg_length = int(header)
			msg = self.client.recv(msg_length).decode('utf-8')
			if msg == HANDSHAKE_MESSAGE:
				self.client.send(b'Hi')
			if msg == DISCONNECT_MESSAGE:
				self.connected = False
		self.client.close()
		self.server.disconnect_client(self)

	def __eq__(self, other):
		return type(other) is type(self) and self.conn_id == other.conn_id

	def __hash__(self):
		return 31 * hash('ClientConnection') + hash(self.conn_id)

	@classmethod
	def get_and_set_next_id(cls):
		val = cls.connectionid
		cls.connectionid += 1
		return val


class ServerContext:
	def __init__(self):
		self.server = socket.socket()
		self.port = 9009
		self.ip = socket.gethostbyname(socket.gethostname()) # 192.168.0.2
		self.clients = set()

	def bind_and_listen(self):
		self.server.bind((self.ip, self.port))
		self.server.listen()
		while True:
			clientsocket, address = self.server.accept()
			new_client = ClientConnection(clientsocket, address, self)
			self.clients.add(new_client)
			new_client.start_and_run()

	def disconnect_client(self, client):
		self.clients.remove(client)


def main():
	server = ServerContext()
	server.bind_and_listen()


if __name__ == '__main__':
	main()
	input()
