using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlay : MonoBehaviour
{
	public GamePlayer player;
	public GamePlayer opponent;

	public void Attack(CombatCard attackingCard, CombatCard defendingCard)
	{
		if (attackingCard != null && defendingCard != null)
		{
			ElementAttack attackAnimation = Instantiate(attackingCard.Card.CardElement.AttackAnimationPrefab) as ElementAttack;
			attackAnimation.InitializeAttack(attackingCard.transform.position, defendingCard.transform.position);
			int netResult = GetAttackNetResult(attackingCard, defendingCard);
		}
	}

	private int GetAttackNetResult(CombatCard attackingCard, CombatCard defendingCard)
	{
		int netDefense = defendingCard.Card.Defense;
		if (defendingCard.Card.CardElement.IsVulnerableTo(attackingCard.Card.CardElement))
		{
			netDefense = defendingCard.Card.Defense / 2;
		}
		else if (defendingCard.Card.CardElement.IsResistantTo(attackingCard.Card.CardElement))
		{
			netDefense = defendingCard.Card.Defense * 2;
		}
		int netResult = attackingCard.Card.Attack - netDefense;
		if (netResult >= 0)
		{
			defendingCard.KillCard();
			defendingCard.Player.Health -= netResult;
			if (defendingCard.Player.Health == 0)
			{
				GameOver();
			}
		}
		return netResult;
	}

	private void GameOver()
	{

	}
}
