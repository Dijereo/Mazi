﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHand : MonoBehaviour
{
	public float CardYPos;
	public float CardZPos;
    public CardView CardPrefab;
    public GameArea CardPlayArea;
    public GamePlay gamePlay;
    public GameNetworkDirector gameDirector;
    public List<PlayableCard> Cards = new List<PlayableCard>();

    public void AddCard(CardData card)
    {
    	CardView newcard = Instantiate(CardPrefab) as CardView;
        newcard.Card = card;
    	newcard.InitializeData();
        PlayableCard playcard = newcard.gameObject.AddComponent<PlayableCard>();
        playcard.Hand = this;
        playcard.Card = card;
    	Cards.Add(playcard);
    	RearrangeCards();
    }

    private void RearrangeCards() {
    	float width = 1.1f * Cards.Count - 0.1f;
    	for (int i = 0; i < Cards.Count; i++)
    	{
    		Cards[i].transform.position = new Vector3(i * 1.1f - width / 2f, CardYPos, CardZPos);
    	}
    }

    public void PlayCard(PlayableCard card)
    {
        Cards.Remove(card);
        RearrangeCards();
        CardPlayArea.AddCard(card.Card);
        Destroy(card.gameObject);
    }

    public void PlayCardByIndex(int i)
    {
        PlayableCard card = Cards[i];
        PlayCard(card);
    }
}
