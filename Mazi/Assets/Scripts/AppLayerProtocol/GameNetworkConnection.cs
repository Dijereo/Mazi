using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;


public class GameNetworkConnection : MonoBehaviour
{
	private string authtoken;
    private string gametoken;
	private SocketWrapper socket;
	private Thread threadcaller;
	private int i;
	private bool connected = true;
	private bool receiving = true;
	public GameNetworkDirector gamedirector;

    void Start()
    {
        i = 0;
        gametoken = QueueConnection.Gametoken;
        authtoken = QueueConnection.Authtoken;
    	socket = new SocketWrapper(new byte[] {192, 168, 0, 2}, 9011);
        threadcaller = new Thread(new ThreadStart(this.Handle));
        threadcaller.Start();
    }

    void Update() {
        i += 1;
        if (i == 60)
        {
            i = 0;
            Thread.Sleep(1);
        }
    }

    public void Send(string data)
    {
        socket.Send(data);
    }

    private void Handle()
    {
        try
        {
            socket.Connect();
            socket.Send(gametoken);
            socket.Send(authtoken);
            string initstatus = socket.Recv();
            Debug.Log(initstatus);
            string gamedata = socket.Recv();
            while (connected)
            {
            	if (receiving)
            	{
            		string gameaction = socket.Recv();
            		gamedirector.SetCommand(gameaction);
            	}
            	else {
            		Thread.Sleep(1000);
            	}
            }

        }
        catch (SocketException se)
        {
            Console.WriteLine("SocketException : {0}", se.ToString());
        }
        finally
        {
            socket.Close();
        }
    }
}
