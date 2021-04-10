using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;


public class SocketWrapper
{
	private static int META_LENGTH = 8;
	private IPEndPoint ipEndPoint;
	private Socket socket;
	
	public SocketWrapper(byte[] ipByteAddress, int port)
	{
		IPAddress ipAddress = new IPAddress(ipByteAddress);
		ipEndPoint = new IPEndPoint(ipAddress, port);
		socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
	}

	public void Connect()
	{
		socket.Connect(ipEndPoint);
	}

	public void Send(string msg)
	{
		byte[] msgbytes = Encoding.ASCII.GetBytes(msg);
		byte[] msglen = Encoding.ASCII.GetBytes(msgbytes.Length.ToString());
		int metalen = socket.Send(msglen);
		int bytessent = socket.Send(msgbytes);
	}

	public string Recv()
	{
		byte[] msglenbytes = new byte[META_LENGTH];
		int lenbytesrecv = socket.Receive(msglenbytes);
		while (lenbytesrecv == 0)
		{
			lenbytesrecv = socket.Receive(msglenbytes);
		}
		int msglen = Int32.Parse(Encoding.ASCII.GetString(msglenbytes, 0, lenbytesrecv));
		byte[] msgbytes = new byte[msglen];
		int msglenrecv = socket.Receive(msgbytes);
		return Encoding.ASCII.GetString(msgbytes, 0, msglenrecv);
	}

	public void Close()
	{
		socket.Shutdown(SocketShutdown.Both);
		socket.Close();
	}
}
