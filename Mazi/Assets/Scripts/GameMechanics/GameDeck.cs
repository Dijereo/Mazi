using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDeck : MonoBehaviour
{
	private ArrayList Cards = new ArrayList();
	public GameHand Hand;
	public GameElement CardElement;
	public Sprite CardSprite;

	public void InitializeCards(ArrayList cards)
	{
		Cards = cards;
	}

    void OnMouseDown()
    {
    	CardStats card = new CardStats("Dragon", 5, 4, 3, CardElement, CardSprite);
    	Hand.AddCard(card);
    }
}
