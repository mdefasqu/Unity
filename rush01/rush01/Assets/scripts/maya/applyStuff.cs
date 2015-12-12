using UnityEngine;
using System.Collections;

public class applyStuff : MonoBehaviour {

	private bool statsApply = false;
	public GameObject stuffPanel;

	private int oldConstitution = 0;
	private int oldStrengh = 0;
	private int oldAgility = 0;
	private int oldArmor = 0;
	private int oldregenRate = 0;
	private int oldDommageMin = 0;
	private int oldDommageMax = 0;

	public GameObject rightSwordHandle;
	public GameObject[] Weapons;
	// Use this for initialization
	void Start () {

	}

	void setToZero(){
		oldConstitution = 0;
		oldStrengh = 0;
		oldAgility = 0;
		oldArmor = 0;
		oldregenRate = 0;
		oldDommageMin = 0;
		oldDommageMax = 0;
	}

	void resetStuff(){
		gameObject.GetComponent<stats> ().Constitution -= oldConstitution;
		gameObject.GetComponent<stats> ().Strengh -= oldStrengh;
		gameObject.GetComponent<stats> ().Agility -= oldAgility;
		gameObject.GetComponent<stats> ().Armor -= oldArmor;
		gameObject.GetComponent<stats> ().regenRate -= oldregenRate;
		gameObject.GetComponent<stats> ().minDmg -= oldDommageMin;
		gameObject.GetComponent<stats> ().maxDmg -= oldDommageMax;
	}

	void addStuff(){
		gameObject.GetComponent<stats> ().Constitution += oldConstitution;
		gameObject.GetComponent<stats> ().Strengh += oldStrengh;
		gameObject.GetComponent<stats> ().Agility += oldAgility;
		gameObject.GetComponent<stats> ().Armor += oldArmor;
		gameObject.GetComponent<stats> ().regenRate += oldregenRate;
		gameObject.GetComponent<stats> ().minDmg += oldDommageMin;
		gameObject.GetComponent<stats> ().maxDmg += oldDommageMax;
	}

	void saveOld(GameObject weapon){
		oldConstitution =  weapon.GetComponent<WeaponIcon>().Constitution;
		oldStrengh = weapon.GetComponent<WeaponIcon>().Strengh;
		oldAgility = weapon.GetComponent<WeaponIcon>().Agility;
		oldArmor = weapon.GetComponent<WeaponIcon>().Armor;
		oldregenRate = weapon.GetComponent<WeaponIcon>().regenRate;
		oldDommageMin = weapon.GetComponent<WeaponIcon>().DommageMin;
		oldDommageMax = weapon.GetComponent<WeaponIcon>().DommageMax;
	}

	void showWeapon(){
		if (stuffPanel.transform.GetChild (0).transform.childCount == 0 && rightSwordHandle.transform.childCount > 0) {
			Destroy(rightSwordHandle.transform.GetChild(0).gameObject);
		} else if (stuffPanel.transform.GetChild (0).transform.childCount > 0 && rightSwordHandle.transform.childCount == 0){
			GameObject toInst;

			toInst = Instantiate(Weapons[stuffPanel.transform.GetChild (0).transform.GetChild(0).GetComponent<WeaponIcon>().ID], rightSwordHandle.transform.position, Quaternion.identity) as GameObject;

			toInst.transform.rotation = rightSwordHandle.transform.rotation;
			toInst.transform.SetParent(rightSwordHandle.transform);
		}
	}

	// Update is called once per frame
	void Update () {
		if(stuffPanel.transform.GetChild(0).transform.childCount > 0 && statsApply == false){
			saveOld(stuffPanel.transform.GetChild(0).transform.GetChild(0).gameObject);
			addStuff();
			statsApply = true;
		} else if(stuffPanel.transform.GetChild(0).transform.childCount == 0 && statsApply == true) {
			resetStuff();
			statsApply = false;
		}
		showWeapon ();
	}
}
