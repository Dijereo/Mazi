using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHand : MonoBehaviour
{
	public float ypos;
	public float zpos;
    private ArrayList cards = new ArrayList();

    public void AddCard(CardShown card) {
    	cards.Add(card);
    	RearrangeCards();
    }

    private void RearrangeCards() {
    	int n = cards.Count;
    	float width = -0.1f;
    	for (int i = 0; i < cards.Count; i++)
    	{
    		width += 1.1f;
    	}
    	for (int i = 0; i < cards.Count; i++)
    	{
    		CardShown card = (CardShown) cards[i];
    		card.transform.position = new Vector3(i * 1.1f - width / 2f, ypos, zpos);
    	}
    }
}
