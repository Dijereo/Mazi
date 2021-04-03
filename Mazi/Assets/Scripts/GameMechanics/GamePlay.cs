using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlay : MonoBehaviour
{
	public int PlayerHealth = 20;
	public int OpponentHealth = 20;
	public TMP_Text PlayerHealthText;
	public TMP_Text OpponentHealthText;
	public AttackerCard Attacker = null;
	public DefenderCard Defender = null;
	public ElementAttack AttackElement;

	public void Attack()
	{
		if (Attacker != null && Defender != null)
		{
			ElementAttack attackAnimation = Instantiate(AttackElement) as ElementAttack;
			attackAnimation.InitializeAttack(Attacker.transform.position, Defender.transform.position);
		}
	}
}
