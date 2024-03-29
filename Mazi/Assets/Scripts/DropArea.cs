﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData){
            Debug.Log("On Drop");
            if(eventData.pointerDrag != null ){
                //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
                d.setParentToReturnTo(this.transform);
            }
    }
    
}
