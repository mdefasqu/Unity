using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class update_life : MonoBehaviour {

	int hp;
	Text text;

	// Update is called once per frame
	void Update () {
		hp = gameManager.gm.playerHp;
		GetComponent<Text>().text = hp.ToString();
	}
}
