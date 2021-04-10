using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNetworkDirector : MonoBehaviour
{
	public GameDeck deck;
	public GameNetworkConnection gameconnection;
	private Queue<string> commands = new Queue<string>();

	void Update()
	{
		if (commands.Count > 0)
		{
			RunCommand();
		}
	}

	public void SetCommand(string data)
	{
		commands.Enqueue(data);
	}

    public void RunCommand()
    {
    	string data = commands.Dequeue();
    	if (data == "DRAWCARD")
    	{
    		deck.DrawCard();
    	}
    }

    public void SendCommand(string data)
    {
    	gameconnection.Send(data);
    }
}
