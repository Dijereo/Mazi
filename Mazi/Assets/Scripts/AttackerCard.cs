﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerCard : CombatCard
{
	void OnMouseDown()
	{
		Game.Attacker = this;
	}
}
