using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHand : MonoBehaviour
{
	public float CardYPos;
	public float CardZPos;
    public CardView CardPrefab;
    public GameArea CardPlayArea;
    private ArrayList Cards = new ArrayList();

    public void AddCard(CardStats card)
    {
    	CardView newcard = Instantiate(CardPrefab) as CardView;
        newcard.Stats = card;
    	newcard.InitializeStats();
        PlayableCard playcard = newcard.gameObject.AddComponent<PlayableCard>();
        playcard.Hand = this;
        playcard.Stats = card;
    	Cards.Add(playcard);
    	RearrangeCards();
    }

    private void RearrangeCards() {
    	float width = 1.1f * Cards.Count - 0.1f;
    	for (int i = 0; i < Cards.Count; i++)
    	{
    		PlayableCard card = (PlayableCard) Cards[i];
    		card.transform.position = new Vector3(i * 1.1f - width / 2f, CardYPos, CardZPos);
    	}
    }

    public void PlayCard(PlayableCard card)
    {
        Cards.Remove(card);
        RearrangeCards();
        CardPlayArea.AddCard(card.Stats);
        Destroy(card.gameObject);
    }
}
