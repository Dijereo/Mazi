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
        UTF8Encoding utf8 = new UTF8Encoding();
        byte[] msgAsBytes = utf8.GetBytes(msg);
		byte[] msgLenAsBytes = utf8.GetBytes(msgAsBytes.Length.ToString());
        byte[] msgLenAsBytesPadded = new byte[] {32, 32, 32, 32, 32, 32, 32, 32};
        int difference = msgLenAsBytesPadded.Length - msgLenAsBytes.Length;
        for (int i = 0; i < msgLenAsBytes.Length; i++)
        {
            msgLenAsBytesPadded[difference + i] = msgLenAsBytes[i];
        }
		Debug.Log("MSGLEN\n" + msgAsBytes.Length.ToString());
		int metalen = socket.Send(msgLenAsBytesPadded);
		Debug.Log("MSG\n" + msgAsBytes);
		int bytessent = socket.Send(msgAsBytes);
	}

	public string Recv()
	{
        UTF8Encoding utf8 = new UTF8Encoding();
		byte[] msglenbytes = new byte[META_LENGTH];
		int lenbytesrecv = socket.Receive(msglenbytes);
		while (lenbytesrecv == 0)
		{
			lenbytesrecv = socket.Receive(msglenbytes);
		}
		int msglen = Int32.Parse(utf8.GetString(msglenbytes, 0, lenbytesrecv));
		byte[] msgbytes = new byte[msglen];
		int msglenrecv = socket.Receive(msgbytes);
		return utf8.GetString(msgbytes, 0, msglenrecv);
	}

	public void Close()
	{
		socket.Shutdown(SocketShutdown.Both);
		socket.Close();
	}
}
