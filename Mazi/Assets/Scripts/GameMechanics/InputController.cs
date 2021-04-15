using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputController : MonoBehaviour
{
	public AttackerCard Attacker = null;
	public DefenderCard Defender = null;
	public GamePlay gamePlay;
	public GameNetworkDirector gameDirector;

	public void MakeSelectedAttack()
	{
		if (gamePlay.isMyTurn)
		{
			string attackCardIndex = Attacker.Area.Cards.IndexOf(Attacker).ToString();
			string defenseCardIndex = Defender.Area.Cards.IndexOf(Defender).ToString();
			gameDirector.SendCommand("ATTACK " + attackCardIndex + " " + defenseCardIndex);
			gamePlay.Attack(Attacker, Defender);
		}
		Attacker = null;
		Defender = null;
	}
}
