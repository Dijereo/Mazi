using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
	public float CardYPos;
	public float CardZPos;
    public CombatCard CardPrefab;
    public GamePlayer Player;
    public InputController controller;
    private List<CombatCard> Cards = new List<CombatCard>();

    public void AddCard(CardData card)
    {
    	CombatCard newcard = Instantiate(CardPrefab) as CombatCard;
        newcard.Card = card;
        newcard.Area = this;
        newcard.Player = Player;
        newcard.controller = controller;
        newcard.InitializeData();
    	Cards.Add(newcard);
    	RearrangeCards();
    }

    public void RemoveCard(CombatCard card)
    {
        Cards.Remove(card);
        RearrangeCards();
        Destroy(card.gameObject);
    }

    private void RearrangeCards() {
    	float width = 1.1f * Cards.Count - 0.1f;
    	for (int i = 0; i < Cards.Count; i++)
    	{
    		Cards[i].transform.position = new Vector3(i * 1.1f - width / 2f, CardYPos, CardZPos);
    	}
    }
}
