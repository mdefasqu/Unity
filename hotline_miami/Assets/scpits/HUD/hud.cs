using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hud : MonoBehaviour {

	public GameObject hero;

	private string weapon_name;
	private string ammo;
	private string type;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (hero.GetComponent<hero> ().equipWeapon != null) {
			weapon_name = hero.GetComponent<hero> ().equipWeapon.GetComponent<weapon_spawner> ().currentWeapon.name;
			ammo = hero.GetComponent<hero> ().equipWeapon.GetComponent<weapon_spawner> ().ammo.ToString ();
			type = hero.GetComponent<hero> ().equipWeapon.GetComponent<weapon_spawner> ().currentWeapon.GetComponent<weapon_stat>().type;
		} else {
			weapon_name = "no weapon";
			ammo = "-";
			type = "";
		}



		transform.GetChild (0).GetComponent<Text> ().text = weapon_name;
		transform.GetChild (1).GetComponent<Text> ().text = ammo;
		transform.GetChild (2).GetComponent<Text> ().text = type;
	}
}
