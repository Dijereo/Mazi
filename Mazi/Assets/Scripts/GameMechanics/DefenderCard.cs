using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCard : CombatCard
{
	void OnMouseDown()
	{
		controller.Defender = this;
		controller.MakeSelectedAttack();
	}
}
