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

	public void InitializeCards(List<CardData> cards)
	{
		Cards = cards;
	}

	public void DrawCard()
	{
    	CardData card = new CardData("Dragon", 5, 4, 3, CardElement, CardSprite);
    	Hand.AddCard(card);
    	if (playerOwned)
    	{
    		director.SendCommand("DRAWCARD");
    	}
	}

    void OnMouseDown()
    {
    	if (playerOwned)
    	{
    		DrawCard();
    	}
    }
}
