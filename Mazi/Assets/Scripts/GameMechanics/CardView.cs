using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
	public CardData Card;

	void Start()
	{
		InitializeData();
	}

    public virtual void InitializeData()
    {

    }
}
