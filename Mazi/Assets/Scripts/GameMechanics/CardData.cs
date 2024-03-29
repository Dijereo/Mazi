﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData
{
	public string CardName;
	public int Attack;
	public int Defense;
	public int Energy;
	public GameElement CardElement;
	public Sprite CardSprite;

	public CardData(string cardName, int attack, int defense, int energy,
		GameElement cardElement, Sprite cardSprite)
	{
		CardName = cardName;
		Attack = attack;
		Defense = defense;
		Energy = energy;
		CardElement = cardElement;
		CardSprite = cardSprite;
	}
}
