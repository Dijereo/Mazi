using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
	private bool indeck = true;
	private bool inhand = false;

    void OnMouseDown()
    {
        DrawThisCard();
    }

    public void DrawThisCard()
    {
        indeck = false;
        float xtarget = 1.5f;
    }

    void Update()
    {
    	if (!indeck && !inhand)
    	{
    		transform.Translate((new Vector3(-4, 0, 0)) * Time.deltaTime, Space.World);
    		if (transform.position.x > 0) {
    			transform.position = new Vector3(0f, -3.5f, -1f);
    			inhand = true;
    		}
    	}
    }
}
