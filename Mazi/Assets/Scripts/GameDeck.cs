using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDeck : MonoBehaviour
{
	private ArrayList cards = new ArrayList();
	public Sprite el;
	public Sprite dragon;
	public GameHand hand;

	void Start()
	{
		//CardShown newcard = new CardShown();
		//newcard.SetAttributes("Fire Dragon", 5, 4, 3, el, dragon);
		//cards.Add(newcard);
		//Debug.Log(cards.Count);
	}

    void OnMouseDown()
    {
    	//CardShown newcard = (CardShown) cards[0];
    	hand.AddCard("Fire Dragon", 5, 4, 3, el, dragon);
    }
}
