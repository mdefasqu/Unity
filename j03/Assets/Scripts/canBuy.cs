using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canBuy : MonoBehaviour {

	int energy;
	
	// Update is called once per frame
	void Update () {
		energy = gameManager.gm.playerEnergy;
		if (energy < GetComponent<dragAndDrop> ().itemToDrag.GetComponent<towerScript> ().energy) {
			GetComponent<dragAndDrop> ().enabled = false;
			GetComponent<Image> ().color = Color.red;
		} else {
			GetComponent<dragAndDrop> ().enabled = true;
			GetComponent<Image> ().color = Color.white;
		}
	}
}
