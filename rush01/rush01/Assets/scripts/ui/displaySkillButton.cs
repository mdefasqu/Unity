using UnityEngine;
using System.Collections;

public class displaySkillButton : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<stats> ().skills > 0) {
			transform.GetChild (10).gameObject.SetActive (true);
		} else {
			transform.GetChild (10).gameObject.SetActive (false);
		}
	}
}
