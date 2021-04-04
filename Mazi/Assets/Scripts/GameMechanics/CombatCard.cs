using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCard : MonoBehaviour
{
	public CardData Card;
	public CardView Prefab;
	public GameArea Area;
	public GamePlayer Player;
	public InputController controller;

	public void InitializeData()
	{
		Prefab.Card = Card;
		Prefab.InitializeData();
	}

	public void KillCard()
	{
		Area.RemoveCard(this);
	}
}
