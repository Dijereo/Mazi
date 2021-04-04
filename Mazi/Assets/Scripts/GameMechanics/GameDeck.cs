using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDeck : MonoBehaviour
{
	private List<CardData> Cards = new List<CardData>();
	public GameHand Hand;
	public GameElement CardElement;
	public Sprite CardSprite;

	public void InitializeCards(List<CardData> cards)
	{
		Cards = cards;
	}

    void OnMouseDown()
    {
    	CardData card = new CardData("Dragon", 5, 4, 3, CardElement, CardSprite);
    	Hand.AddCard(card);
    }
}
