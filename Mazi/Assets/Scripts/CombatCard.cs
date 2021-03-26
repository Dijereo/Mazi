using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCard : MonoBehaviour
{
	public CardStats Stats;
	public Gameplay Game;
	public CardView Prefab;

	public void InitializeStats()
	{
		Prefab.Stats = Stats;
		Prefab.InitializeStats();
	}
}
