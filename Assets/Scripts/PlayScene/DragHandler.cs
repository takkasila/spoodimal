using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour,  IBeginDragHandler, IDragHandler, IEndDragHandler{

    public int foodValue = 1;

    public static GameObject itemBeingDragged;
    Vector3 startPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPos = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit, 50))
        {
            GameObject parentOfHitObject = hit.collider.gameObject.transform.parent.gameObject;
            parentOfHitObject.SendMessage("gotFood", foodValue, SendMessageOptions.DontRequireReceiver);
        }

        itemBeingDragged = null;
        transform.position = startPos;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
