using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour {

	public GameObject[] slots;


	// Use this for initialization
	void Start () {
		//slots = GameObject.FindGameObjectsWithTag ("Slot_Inventory");
		Debug.Log (slots.Length);
	}

	private int checkSpace(){
		int freeSpace = 0;
		foreach (GameObject item in slots) {
			if(item.transform.childCount == 0){
				freeSpace++;
			}
		}
		return freeSpace;
	}

	private GameObject validSlot(){
		foreach (GameObject item in slots) {
			if(item.transform.childCount == 0){
				return item;
			}
		}
		return null;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			if (checkSpace () > 0) {

				Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (cursorRay.origin, cursorRay.direction, out hit, 100)) {
					if (hit.collider.tag == "Weapon") {
						GameObject parent = validSlot ();
						GameObject itemIcon = Instantiate (hit.collider.GetComponent<Weapon> ().icon, parent.transform.position, Quaternion.identity) as GameObject;
						itemIcon.transform.SetParent (parent.transform);
						itemIcon.GetComponent<WeaponIcon>().getStats(hit.collider.gameObject);
						Destroy(hit.collider.gameObject);
					}
				}
			}
		}
	}
}
