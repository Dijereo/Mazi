using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayer : MonoBehaviour
{
	private int health = 20;
	public TMP_Text healthText;
	
	public int Health {
		get { return health; }
		set
		{
			health = value >= 0 ? value : 0;
			healthText.text = health.ToString();
		}
	}
}
