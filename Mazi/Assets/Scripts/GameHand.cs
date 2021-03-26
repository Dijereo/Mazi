using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHand : MonoBehaviour
{
	public float CardYPos;
	public float CardZPos;
    public CardView CardPrefab;
    private ArrayList Cards = new ArrayList();

    public void AddCard(CardStats card)
    {
    	CardView newcard = Instantiate(CardPrefab) as CardView;
        newcard.Stats = card;
    	newcard.InitializeStats();
    	Cards.Add(newcard);
    	RearrangeCards();
    }

    private void RearrangeCards() {
    	float width = 1.1f * Cards.Count - 0.1f;
    	for (int i = 0; i < Cards.Count; i++)
    	{
    		CardView card = (CardView) Cards[i];
    		card.transform.position = new Vector3(i * 1.1f - width / 2f, CardYPos, CardZPos);
    	}
    }
}
