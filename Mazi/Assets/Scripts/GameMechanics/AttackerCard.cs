using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerCard : CombatCard
{
	void OnMouseDown()
	{
		controller.Attacker = this;
	}
}
