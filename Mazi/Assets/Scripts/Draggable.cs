using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    public string m_text;
    private RectTransform RectTransform;
    private CanvasGroup canvasGroup;
    private Transform parentToReturnTo = null;

    public void Awake(){

        RectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
    }
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeginDrag");
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("OnDrag");
        RectTransform.anchoredPosition += eventData.delta/70;
        //this.transform.position = eventData.position;
        m_text = "Position:" + this.transform.position + "Mouse: " + eventData.position;
        //m_text = "Mouse position: " + eventData.position + "Card Position: " + this.position;
        Debug.Log(m_text);
        Debug.Log("   " + canvas.scaleFactor);
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        this.transform.SetParent(parentToReturnTo);
    }

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }
    
    public void setParentToReturnTo(Transform t){

        this.parentToReturnTo = t;
    }
    
}
