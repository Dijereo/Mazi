using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
	public CardStats Stats;

	void Start()
	{
		InitializeStats();
	}

    public virtual void InitializeStats()
    {

    }
}
