using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot_inventory : MonoBehaviour, IDropHandler {
	public GameObject item {
		get {
			if(transform.childCount>0){
				return transform.GetChild(0).gameObject;
			}
			return null;
		}
	}
	
	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if (!item && dragHandelerInventory.weaponBeingDragged != null) {
			dragHandelerInventory.weaponBeingDragged.transform.SetParent(transform);
		}
	}
	#endregion
}
