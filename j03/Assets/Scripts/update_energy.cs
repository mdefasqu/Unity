using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class update_energy : MonoBehaviour {

	int energy;
	Text text;
	
	// Update is called once per frame
	void Update () {
		energy = gameManager.gm.playerEnergy;
		GetComponent<Text>().text = energy.ToString();
	}
}
