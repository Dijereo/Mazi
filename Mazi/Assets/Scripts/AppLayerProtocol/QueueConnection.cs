using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;


public class QueueConnection : MonoBehaviour
{
	private string authtoken;
    private string gametoken;
	private SocketWrapper socket;
	private Thread threadcaller;
    public MainMenu mainmenu;
    public static string Gametoken;
    public static string Authtoken;
    private int i;

    void Start()
    {
        i = 0;
        Gametoken = null;
        Authtoken = null;
    	socket = new SocketWrapper(new byte[] {192, 168, 0, 2}, 9010);
        threadcaller = new Thread(new ThreadStart(this.Handle));
    }

    void Update() {
        i += 1;
        if (i == 60)
        {
            i = 0;
            Thread.Sleep(1);
        }
    }

    public void StartThread(string token)
    {
    	authtoken = token;
        threadcaller.Start();
    }

    private void Handle()
    {
        try
        {
            socket.Connect();
            socket.Send(authtoken);
            gametoken = socket.Recv();
            Debug.Log(gametoken);
        }
        catch (SocketException se)
        {
            Console.WriteLine("SocketException : {0}", se.ToString());
        }
        finally
        {
            socket.Close();
            Gametoken = gametoken;
            Authtoken = authtoken;
            mainmenu.StartMatch();
        }
    }
}
