using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class refreshUI : MonoBehaviour {

	Text currentXP;
	Text targetXP;
	Text level;
	Text life;
	GameObject xpBar;
	GameObject lifeBar;
	[HideInInspector] public GameObject player;

	GameObject FlifeBar;
	Text Flife;
	Text Flvl;
	Text Fname;
	GameObject toolTip;

	float Pourcentage(int current, int max){
		float result = (current * 100) / max;
		result = result / 100;
		return (result);
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		player = GameObject.FindGameObjectWithTag ("Player");

		xpBar = transform.GetChild(0).transform.GetChild(0).gameObject;		
		lifeBar = transform.GetChild (1).transform.GetChild (0).gameObject;
		life = transform.GetChild (1).transform.GetChild (1).GetComponent<Text> ();
		level = transform.GetChild (1).transform.GetChild (2).GetComponent<Text> ();
		currentXP = transform.GetChild (2).transform.GetChild (0).GetComponent<Text> ();
		targetXP = transform.GetChild (2).transform.GetChild (1).GetComponent<Text> ();

		FlifeBar = transform.GetChild (3).transform.GetChild (0).gameObject;
		Flife = transform.GetChild (3).transform.GetChild (1).GetComponent<Text> ();
		Flvl = transform.GetChild (3).transform.GetChild (2).GetComponent<Text> ();
		Fname = transform.GetChild (3).transform.GetChild (3).GetComponent<Text> ();

		toolTip = transform.GetChild (9).gameObject;
		toolTip.SetActive (false);
	}


	void showTooltipWeapon(GameObject tool){
		if (tool.tag == "Weapon") {
			toolTip.transform.GetChild (0).GetComponent<Text> ().text = "Constitution : " + tool.GetComponent<Weapon> ().Constitution +
				"\nStrengh : " + tool.GetComponent<Weapon> ().Strengh +
				"\nAgility : " + tool.GetComponent<Weapon> ().Agility +
				"\nArmor : " + tool.GetComponent<Weapon> ().Armor +
				"\nRegen Rate : " + tool.GetComponent<Weapon> ().regenRate +
				"\nDammages (min/max) : +" + tool.GetComponent<Weapon> ().DommageMin + "/+" + tool.GetComponent<Weapon> ().DommageMax +
				"\nAttack Speed : " + tool.GetComponent<Weapon> ().atk_speed +
				"\nItem Level : " + tool.GetComponent<Weapon> ().item_level;
			if (tool.GetComponent<Weapon> ().quality == 1) {
				toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.white;
			} else if (tool.GetComponent<Weapon> ().quality == 2) {
				toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.green;
			} else if (tool.GetComponent<Weapon> ().quality == 4) {
				toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.blue;
			} else if (tool.GetComponent<Weapon> ().quality == 8) {
				toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.magenta;
			} else {
				toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.gray;
			}
			toolTip.SetActive (true);
		}
	}

	void showTooltipSpell(){
		PointerEventData cursor = new PointerEventData(EventSystem.current);                            // This section prepares a list for all objects hit with the raycast
		cursor.position = Input.mousePosition;
		List<RaycastResult> objectsHit = new List<RaycastResult> ();
		EventSystem.current.RaycastAll(cursor, objectsHit);
		int count = objectsHit.Count;
		if (count > 0) {
			if(objectsHit[0].gameObject.tag == "Spell"){
				toolTip.SetActive (true);
				if(objectsHit[0].gameObject.name == "spell0")
					toolTip.transform.GetChild (0).GetComponent<Text> ().text = objectsHit[0].gameObject.GetComponent<spell0>().getToolTip();
				else if(objectsHit[0].gameObject.name == "spell1"){
					toolTip.transform.GetChild (0).GetComponent<Text> ().text = objectsHit[0].gameObject.GetComponent<spell1>().getToolTip();
				} else if(objectsHit[0].gameObject.name == "spell2"){
					toolTip.transform.GetChild (0).GetComponent<Text> ().text = objectsHit[0].gameObject.GetComponent<spell2>().getToolTip();
				} else if(objectsHit[0].gameObject.name == "spell3"){
					toolTip.transform.GetChild (0).GetComponent<Text> ().text = objectsHit[0].gameObject.GetComponent<spell3>().getToolTip();
				} else if(objectsHit[0].gameObject.name == "spell4"){
					toolTip.transform.GetChild (0).GetComponent<Text> ().text = objectsHit[0].gameObject.GetComponent<spell4>().getToolTip();
				} else if(objectsHit[0].gameObject.name == "spell5"){
					toolTip.transform.GetChild (0).GetComponent<Text> ().text = objectsHit[0].gameObject.GetComponent<spell5>().getToolTip();
				}

			} else if (objectsHit[0].gameObject.tag == "WeaponUI" && Input.GetKeyDown(KeyCode.Delete)){
				Destroy(objectsHit[0].gameObject);
			} else if (objectsHit[0].gameObject.tag == "WeaponUI"){
				toolTip.SetActive (true);
				toolTip.transform.GetChild (0).GetComponent<Text> ().text = "Constitution : " + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().Constitution +
					"\nStrengh : " + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().Strengh +
						"\nAgility : " + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().Agility +
						"\nArmor : " + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().Armor +
						"\nRegen Rate : " + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().regenRate +
						"\nDammages (min/max) : +" + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().DommageMin + "/+" + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().DommageMax +
						"\nAttack Speed : " + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().atk_speed +
						"\nItem Level : " + objectsHit[0].gameObject.GetComponent<WeaponIcon> ().item_level;
				if (objectsHit[0].gameObject.GetComponent<WeaponIcon> ().quality == 1) {
					toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.white;
				} else if (objectsHit[0].gameObject.GetComponent<WeaponIcon> ().quality == 2) {
					toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.green;
				} else if (objectsHit[0].gameObject.GetComponent<WeaponIcon> ().quality == 4) {
					toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.blue;
				} else if (objectsHit[0].gameObject.GetComponent<WeaponIcon> ().quality == 8) {
					toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.magenta;
				} else {
					toolTip.transform.GetChild (0).GetComponent<Text> ().color = Color.gray;
				}
			} else {
				toolTip.SetActive (false);
			}
		}
	}

	void Update () {
		bool touch = false;

		xpBar.transform.localScale = new Vector3 (Pourcentage (player.GetComponent<stats>().xp, player.GetComponent<stats>().xpToUp), 1, 1);
		if (Pourcentage(player.GetComponent<stats>().life, player.GetComponent<stats>().hp) < 0)
			lifeBar.transform.localScale = new Vector3 (0, 1, 1);
		else
			lifeBar.transform.localScale = new Vector3 (Pourcentage(player.GetComponent<stats>().life, player.GetComponent<stats>().hp), 1, 1);
		life.text = player.GetComponent<stats> ().life.ToString();
		level.text = "lv."+ player.GetComponent<stats> ().level.ToString ();
		currentXP.text = player.transform.GetComponent<stats> ().xp.ToString();
		targetXP.text = "/ " + player.transform.GetComponent<stats> ().xpToUp.ToString();

		Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (cursorRay.origin, cursorRay.direction, out hit, 200)) {
			if(hit.collider.tag == "Enemy"){
				touch = true;
			} else if (hit.collider.tag == "Weapon") {
				showTooltipWeapon(hit.collider.gameObject);
			} else {
				toolTip.SetActive (false);
			}
		}

		showTooltipSpell ();

		if (player.GetComponent<attack> ().focusEnemy != null || touch) {
			GameObject focus;
			transform.GetChild(3).gameObject.SetActive(true);

			if (touch) {
				focus = hit.collider.gameObject;
			} else {
				focus = player.GetComponent<attack> ().focusEnemy;
			}

			if (focus != null) {
				if (Pourcentage(focus.GetComponent<stats>().life, focus.GetComponent<stats>().hp) < 0)
					FlifeBar.transform.localScale = new Vector3 (0, 1, 1);
				else
					FlifeBar.transform.localScale = new Vector3 (Pourcentage (focus.GetComponent<stats> ().life, focus.GetComponent<stats> ().hp), 1, 1);
				Flife.text = focus.GetComponent<stats> ().life.ToString ();
				Flvl.text = "lv." + focus.GetComponent<stats> ().level.ToString ();
				Fname.text = focus.GetComponent<stats> ().entityName;
			}
		} else {
			transform.GetChild(3).gameObject.SetActive(false);
		}
	}
}


//Pourcentage(player.GetComponent<stats>().life, player.GetComponent<stats>().hp)