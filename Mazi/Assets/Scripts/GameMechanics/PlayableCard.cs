using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCard : MonoBehaviour
{
	public GameHand Hand;
	public CardData Card;

	void OnMouseDown()
	{
		string cardIndex = Hand.Cards.IndexOf(this).ToString();
		Hand.PlayCard(this);
		Hand.gameDirector.SendCommand("PLAYCARD " + cardIndex);
	}
}
