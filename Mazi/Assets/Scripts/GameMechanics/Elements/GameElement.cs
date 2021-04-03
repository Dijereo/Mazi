using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CardElement")]
public class GameElement : ScriptableObject
{
	public string ElementName;
	public Sprite ElementSprite;
	public ElementAttack AttackAnimationPrefab;

	public bool IsVulnerableTo(GameElement attacker)
	{
		return false;
	}

	public bool IsResistantTo(GameElement attacker)
	{
		return false;
	}
}
