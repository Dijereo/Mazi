using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCard : MonoBehaviour
{
	public GameHand Hand;
	public CardData Card;

	void OnMouseDown()
	{
		Hand.PlayCard(this);
	}
}
