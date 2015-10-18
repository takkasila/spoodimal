using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour,  IBeginDragHandler, IDragHandler, IEndDragHandler{

    public static GameObject itemBeingDragged;
    Vector3 startPos;

	void Start () {
	
	}
	
	void Update () {
	
	}
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.position = startPos;
    }

}
