using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstTest : MonoBehaviour
{
    public OnClickTry cubeprefab;

    /*void OnMouseDown()
    {
        Instantiate(cubeprefab);
    }*/


    void Update()
    {
    	if (Input.GetMouseButtonDown(0))
	    {
	        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
	        RaycastHit hit;    
	        if (Physics.Raycast(ray, out hit, 100))
	        {
	            Debug.Log(hit.transform.gameObject.name);
	        }
	    }
    }
}
