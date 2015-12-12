using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IDropHandler {
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
		if (!item && dragHandeler.itemBeingDragged) {
			if(gameObject.name == ("slot_"+dragHandeler.itemBeingDragged.name) || (gameObject.transform.parent.name == "cast_panel")){
				dragHandeler.itemBeingDragged.transform.SetParent(transform);
			}
		}
	}
	#endregion
}
