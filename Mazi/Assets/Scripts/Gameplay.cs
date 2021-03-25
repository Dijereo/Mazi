using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
	public TMP_Text playerHealthText;
	public GameDeck playerDeck;
	public GameHand playerHand;
	public GameArea playerArea;
	public TMP_Text opponentHealthText;
	public GameDeck opponentDeck;
	public GameHand opponentHand;
	public GameArea opponentArea;
	private CardShown attaker;
	private CardShown defender;

	public void SetAttacker(CardShown a)
	{
		attaker = a;
	}

	public void SetDefender(CardShown d)
	{
		defender = d;
	}

	public void Attack()
	{
		Debug.Log("Hello");
	}
}
