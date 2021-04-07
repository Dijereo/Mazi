import socket


SERVER = '192.168.0.2'
PORT = 9010
META_LENGTH = 8


class MatchQueueConnection:
	def __init__(self, username):
		self.username = username
		self.conn = socket.socket()
		self.conn.connect((SERVER, PORT))

	def get_game_token(self):
		self.send(self.username)
		return self.recv()

	def send(self, msg):
		message = msg.encode('utf-8')
		msg_length = str(len(message)).ljust(META_LENGTH).encode('utf-8')
		self.conn.send(msg_length)
		self.conn.send(message)

	def recv(self):
		msg_length = int(self.conn.recv(META_LENGTH).decode('utf-8'))
		message = self.conn.recv(msg_length).decode('utf-8')
		return message
