using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCard : MonoBehaviour
{
	public GameHand Hand;
	public CardStats Stats;

	void OnMouseDown()
	{
		Hand.PlayCard(this);
	}
}
