using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CardElement")]
public class GameElement : ScriptableObject
{
	public string ElementName;
	public Sprite ElementSprite;
	public ElementAttack AttackAnimationPrefab;
	public List<GameElement> vulnerabilities;
	public List<GameElement> resistances;

	public bool IsVulnerableTo(GameElement attacker)
	{
		return vulnerabilities.Contains(attacker);
	}

	public bool IsResistantTo(GameElement attacker)
	{
		return vulnerabilities.Contains(attacker);
	}
}
