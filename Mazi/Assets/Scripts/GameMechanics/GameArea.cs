using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
	public float CardYPos;
	public float CardZPos;
    public CombatCard CardPrefab;
    public GamePlay Game;
    private ArrayList Cards = new ArrayList();

    public void AddCard(CardData card)
    {
    	CombatCard newcard = Instantiate(CardPrefab) as CombatCard;
    	newcard.Game = Game;
        newcard.Card = card;
        newcard.InitializeData();
    	Cards.Add(newcard);
    	RearrangeCards();
    }

    private void RearrangeCards() {
    	float width = 1.1f * Cards.Count - 0.1f;
    	for (int i = 0; i < Cards.Count; i++)
    	{
    		CombatCard card = (CombatCard) Cards[i];
    		card.transform.position = new Vector3(i * 1.1f - width / 2f, CardYPos, CardZPos);
    	}
    }
}
