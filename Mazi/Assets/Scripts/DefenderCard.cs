using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCard : CombatCard
{
	void OnMouseDown()
	{
		Game.Defender = this;
		Game.Attack();
	}
}
