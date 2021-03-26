using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
	public int PlayerHealth = 20;
	public TMP_Text PlayerHealthText;
	public int OpponentHealth = 20;
	public TMP_Text OpponentHealthText;
	public AttackerCard Attacker;
	public DefenderCard Defender;
	public Fireball AttackAnimation;

	public void Attack()
	{
		Fireball attackAnimation = Instantiate(AttackAnimation) as Fireball;
		attackAnimation.transform.position = Attacker.transform.position + (new Vector3(0, 0, -1));
		attackAnimation.target = Defender.transform.position + (new Vector3(0, 0, -1));
	}
}
