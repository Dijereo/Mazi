using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTry : MonoBehaviour
{
	public Material selectedMaterial;
	public Material deselectedMaterial;
    public SwitchSelectTry selector;

    void OnMouseDown()
    {
        //selector.selectCube(this);
        Debug.Log("hello");
    }

    public void SetSelectMaterial()
    {
    	GetComponent<Renderer>().material = selectedMaterial;
    }

    public void SetDeselectMaterial()
    {
    	GetComponent<Renderer>().material = deselectedMaterial;
    }
}
