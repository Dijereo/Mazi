using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHand : MonoBehaviour
{
	public float ypos;
	public float zpos;
	public bool isAttacker;
	public CardShown cardprefab;
	public Gameplay game;
	public CardShown starter;
    private ArrayList cards = new ArrayList();

    void Start()
    {
    	Debug.Log(this);
    	cards.Add(starter);
    	RearrangeCards();
    }

    public void AddCard(string name, int atk, int def, int en,
    	Sprite el, Sprite sprite)
    {
    	CardShown newcard = Instantiate(cardprefab) as CardShown;
    	newcard.SetAttributes(name, atk, def, en, isAttacker, el, sprite, game);
    	cards.Add(newcard);
    	RearrangeCards();
    }

    private void RearrangeCards() {
    	float width = 1.1f * cards.Count - 0.1f;
    	for (int i = 0; i < cards.Count; i++)
    	{
    		CardShown card = (CardShown) cards[i];
    		card.transform.position = new Vector3(i * 1.1f - width / 2f, ypos, zpos);
    	}
    }
}
