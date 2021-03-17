using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSelectTry : MonoBehaviour
{
    public OnClickTry cube0;
    public OnClickTry cube1;
    public OnClickTry cube2;

    public void selectCube(OnClickTry selectedCube)
    {
    	cube0.SetDeselectMaterial();
    	cube1.SetDeselectMaterial();
    	cube2.SetDeselectMaterial();
    	selectedCube.SetSelectMaterial();
    }
}
