using UnityEngine;
using System.Collections;

public class WeaponIcon : MonoBehaviour {

	public int ID;
	public int Constitution;
	public int Strengh;
	public int Agility;
	public int Armor;
	public int regenRate;
	public int DommageMin;
	public int DommageMax;
	public int atk_speed;
	public int item_level;
	public int quality;


	public void getStats(GameObject referenceWeapon){
		Constitution = referenceWeapon.GetComponent<Weapon> ().Constitution;
		Strengh = referenceWeapon.GetComponent<Weapon> ().Strengh;
		Agility = referenceWeapon.GetComponent<Weapon> ().Agility;
		Armor = referenceWeapon.GetComponent<Weapon> ().Armor;
		regenRate = referenceWeapon.GetComponent<Weapon> ().regenRate;
		DommageMin = referenceWeapon.GetComponent<Weapon> ().DommageMin;
		DommageMax = referenceWeapon.GetComponent<Weapon> ().DommageMax;
		atk_speed = referenceWeapon.GetComponent<Weapon> ().atk_speed;
		item_level = referenceWeapon.GetComponent<Weapon> ().item_level;
		quality = referenceWeapon.GetComponent<Weapon> ().quality;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
