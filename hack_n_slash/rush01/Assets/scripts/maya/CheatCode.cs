using UnityEngine;
using System.Collections;

public class CheatCode : MonoBehaviour {

	public GameObject weapon;
	private GameObject build_weapon;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P))
			gameObject.GetComponent<stats> ().xp = gameObject.GetComponent<stats> ().xpToUp;
		if (Input.GetKeyDown (KeyCode.O)) {
			build_weapon = Instantiate (weapon, transform.localPosition, Quaternion.identity)as GameObject;
			build_weapon.GetComponent<Weapon_spawner>().level = gameObject.GetComponent<stats> ().level;
		}
	}
}
