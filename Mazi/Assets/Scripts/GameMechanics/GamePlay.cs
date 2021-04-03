using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlay : MonoBehaviour
{
	private int playerHealth = 20;
	public int PlayerHealth {
		get { return playerHealth; }
		set
		{
			playerHealth = value >= 0 ? value : 0;
			PlayerHealthText.text = playerHealth.ToString();
		}
	}
	private int opponentHealth = 20;
	public int OpponentHealth {
		get { return opponentHealth; }
		set
		{
			opponentHealth = value >= 0 ? value : 0;
			OpponentHealthText.text = opponentHealth.ToString();
		}
	}
	public TMP_Text PlayerHealthText;
	public TMP_Text OpponentHealthText;
	public AttackerCard Attacker = null;
	public DefenderCard Defender = null;

	public void Attack()
	{
		if (Attacker != null && Defender != null)
		{
			ElementAttack attackAnimation = Instantiate(Attacker.Card.CardElement.AttackAnimationPrefab) as ElementAttack;
			attackAnimation.InitializeAttack(Attacker.transform.position, Defender.transform.position);
			int netResult = GetAttackNetResult();
			Attacker = null;
			Defender = null;
		}
	}

	private int GetAttackNetResult()
	{
		int netDefense = Defender.Card.Defense;
		if (Defender.Card.CardElement.IsVulnerableTo(Attacker.Card.CardElement))
		{
			netDefense = Defender.Card.Defense / 2;
		}
		else if (Defender.Card.CardElement.IsResistantTo(Attacker.Card.CardElement))
		{
			netDefense = Defender.Card.Defense * 2;
		}
		int netResult = Attacker.Card.Attack - netDefense;
		if (netResult >= 0)
		{
			Defender.KillCard();
			PlayerHealth -= netResult;
			if (PlayerHealth == 0)
			{
				PlayerLoses();
			}
		}
		return netResult;
	}

	private void PlayerLoses()
	{

	}
}
