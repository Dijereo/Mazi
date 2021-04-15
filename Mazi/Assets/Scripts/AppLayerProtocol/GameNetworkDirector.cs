using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNetworkDirector : MonoBehaviour
{
	public GameHand opponentHand;
	public GameDeck opponentDeck;
	public GameArea opponentArea;
	public GameArea playerArea;
	public GamePlay gamePlay;
	public GameNetworkConnection gameConnection;
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
    	string[] data = commands.Dequeue().Split(' ');
    	if (data[0] == "DRAWCARD")
    	{
    		opponentDeck.DrawCard();
    	}
    	else if (data[0] == "PLAYCARD")
    	{
    		int cardIndex = Int32.Parse(data[1]);
    		opponentHand.PlayCardByIndex(cardIndex);
    	}
    	else if (data[0] == "ATTACK")
    	{
    		CombatCard attackCard = opponentArea.Cards[Int32.Parse(data[1])];
    		CombatCard defenseCard = playerArea.Cards[Int32.Parse(data[2])];
    		gamePlay.Attack(attackCard, defenseCard);
    	}
    	else if (data[0] == "PLAY")
    	{
    		gamePlay.EndTurn();
    	}
    }

    public void SendCommand(string data)
    {
    	gameConnection.Send(data);
    }
}
