using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class dragAndDrop : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler{
	
	public static GameObject	itemBeingDragged;
	public GameObject 			itemToDrag;
	Vector3 startPosition;

	#region IBeginDragHandler implementation
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
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
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		if (hit) {
			if (hit.collider.gameObject.transform.parent.name.CompareTo("empty") == 0) {
				Vector3 pos = hit.collider.gameObject.transform.position;
				Instantiate(itemToDrag, pos, Quaternion.identity);
				gameManager.gm.playerEnergy -= itemToDrag.GetComponent<towerScript>().energy;
				hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
		itemBeingDragged = null;
		transform.position = startPosition;
	}
	
	#endregion
}