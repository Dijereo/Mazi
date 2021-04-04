using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputController : MonoBehaviour
{
	public AttackerCard Attacker = null;
	public DefenderCard Defender = null;
	public GamePlay gameplay;

	public void MakeSelectedAttack()
	{
		gameplay.Attack(Attacker, Defender);
		Attacker = null;
		Defender = null;
	}
}
