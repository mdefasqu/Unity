using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statsPanel : MonoBehaviour {

	private GameObject player = null;
	private GameObject panel;
	private bool showPanel = false;

	Text Tstrengh;
	Text Tagility;
	Text Tconstitution;
	Text Tarmor;
	Text TskillPoints;
	Text TminDmg;
	Text TmaxDmg;
	Text ThpMax;
	Text Tcredit;
	Text Tregen;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		panel = transform.GetChild (4).gameObject;
		panel.SetActive (false);

		Tstrengh = panel.transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ();
		Tagility = panel.transform.GetChild (1).transform.GetChild (0).GetComponent<Text> ();
		Tconstitution = panel.transform.GetChild (2).transform.GetChild (0).GetComponent<Text> ();
		Tarmor = panel.transform.GetChild (3).transform.GetChild (0).GetComponent<Text> ();
		TskillPoints = panel.transform.GetChild (4).transform.GetChild (0).GetComponent<Text> ();
		TminDmg = panel.transform.GetChild (5).transform.GetChild (0).GetComponent<Text> ();
		TmaxDmg = panel.transform.GetChild (5).transform.GetChild (1).GetComponent<Text> ();
		ThpMax = panel.transform.GetChild (6).transform.GetChild (0).GetComponent<Text> ();
		Tcredit = panel.transform.GetChild (7).transform.GetChild (0).GetComponent<Text> ();
		Tregen = panel.transform.GetChild (8).transform.GetChild (0).GetComponent<Text> ();
	}

	void displayButtons(bool display){
		GameObject strengh = transform.GetChild (4).transform.GetChild (0).transform.GetChild (1).gameObject;
		GameObject agility = transform.GetChild (4).transform.GetChild (1).transform.GetChild (1).gameObject;
		GameObject constitution = transform.GetChild (4).transform.GetChild (2).transform.GetChild (1).gameObject;

		if (display) {
			strengh.SetActive (true);
			agility.SetActive (true);
			constitution.SetActive (true);
		} else {
			strengh.SetActive (false);
			agility.SetActive (false);
			constitution.SetActive (false);
		}
	}

	public void upgradeStrengh(){
		player.GetComponent<stats> ().Strengh += 1;
		player.GetComponent<stats> ().skills -= 1;
	}

	public void upgradeAgility(){
		player.GetComponent<stats> ().Agility += 1;
		player.GetComponent<stats> ().skills -= 1;
	}

	public void upgradeConst(){
		player.GetComponent<stats> ().Constitution += 1;
		player.GetComponent<stats> ().skills -= 1;
	}

	public void turnOn(){
		showPanel = true;
	}

	public void turnOff(){
		showPanel = false;
		panel.SetActive (false);

	}

	void displayStats(){

		Tstrengh.text = player.GetComponent<stats> ().Strengh.ToString();;
		Tagility.text = player.GetComponent<stats> ().Agility.ToString();
		Tconstitution.text = player.GetComponent<stats> ().Constitution.ToString();
		Tarmor.text = player.GetComponent<stats> ().Armor.ToString();
		TskillPoints.text = player.GetComponent<stats> ().skills.ToString ();
		TminDmg.text = player.GetComponent<stats> ().minDmg.ToString();
		TmaxDmg.text = "/ " + player.GetComponent<stats> ().maxDmg.ToString();
		ThpMax.text = player.GetComponent<stats> ().hp.ToString();
		Tcredit.text = player.GetComponent<stats> ().money.ToString();
		Tregen.text = player.GetComponent<stats> ().regenRate.ToString();
		if (player.GetComponent<stats> ().skills > 0) {
			displayButtons (true);
		} else {
			displayButtons (false);
		}
		panel.SetActive (true);

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C) && panel.activeInHierarchy == false) {
			showPanel = true;
		} else if(Input.GetKeyDown (KeyCode.C) && panel.activeInHierarchy == true){
			panel.SetActive(false);
			showPanel = false;
		}
		if (showPanel) {
			displayStats();
		}
	}
}
