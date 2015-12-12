using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class dragHandelerInventory : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
	
	public static GameObject weaponBeingDragged;
	Vector3 startPosition;
	Transform startParent;
	
	#region IBeginDragHandler implementation
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		weaponBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	
	#endregion
	
	#region IDragHandler implementation
	
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	
	#endregion
	
	#region IEndDragHandler implementation
	
	public void OnEndDrag (PointerEventData eventData)
	{
		weaponBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		transform.position = startPosition;
	}
	
	#endregion
	
	
	
}