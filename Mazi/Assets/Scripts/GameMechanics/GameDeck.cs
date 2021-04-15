using Random=System.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDeck : MonoBehaviour
{
	private List<CardData> Cards = new List<CardData>();
	public GameHand Hand;
	public GameElement CardElement;
	public Sprite CardSprite;
	public bool playerOwned;
	public GameNetworkDirector director;
	public CardFactory cardFactory;
	private Random rand = new Random();

	public void InitializeCards(List<CardData> cards)
	{
		Cards = cards;
	}

	public void DrawCard(int cardEnum)
	{
		CardData card;
		if (cardEnum == 0)
		{
			cardEnum = rand.Next(1, 5);
		}
		card = cardFactory.CreateCard(cardEnum);
    	Hand.AddCard(card);
    	if (playerOwned)
    	{
    		director.SendCommand("DRAWCARD " + cardEnum.ToString());
    	}
	}

    void OnMouseDown()
    {
    	if (playerOwned)
    	{
    		DrawCard(0);
    	}
    }
}
