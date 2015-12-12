using UnityEngine;
using System.Collections;

public class InventroyPanel : MonoBehaviour {

	private GameObject inventory;
	private GameObject characterPanel;

	// Use this for initialization
	void Start () {
		inventory = transform.GetChild (8).gameObject;
		characterPanel = transform.GetChild (7).gameObject;
		inventory.SetActive(false);
		characterPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			if(inventory.activeInHierarchy == true){
				inventory.SetActive(false);
				characterPanel.SetActive (false);
			} else {
				inventory.SetActive(true);
				characterPanel.SetActive (true);

			}
		}
	}
}
