using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spellPanel : MonoBehaviour {

	private bool showPanel = false;
	private GameObject panel;
	private GameObject player;

	private GameObject spell0;
	private GameObject spell1;
	private GameObject spell2;
	private GameObject spell3;
	private GameObject spell4;
	private GameObject spell5;


	private GameObject button_spell0;
	private GameObject button_spell1;
	private GameObject button_spell2;
	private GameObject button_spell3;
	private GameObject button_spell4;
	private GameObject button_spell5;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		panel = transform.GetChild (6).gameObject;
		panel.SetActive (false);

		spell0 = panel.transform.GetChild (0).transform.GetChild (0).transform.GetChild (0).gameObject;
		spell1 = panel.transform.GetChild (0).transform.GetChild (1).transform.GetChild (0).gameObject;
		button_spell0 = panel.transform.GetChild (0).transform.GetChild (2).gameObject;
		button_spell1 = panel.transform.GetChild (0).transform.GetChild (3).gameObject;

		spell2 = panel.transform.GetChild (1).transform.GetChild (0).transform.GetChild (0).gameObject;
		spell3 = panel.transform.GetChild (1).transform.GetChild (1).transform.GetChild (0).gameObject;
		button_spell2 = panel.transform.GetChild (1).transform.GetChild (2).gameObject;
		button_spell3 = panel.transform.GetChild (1).transform.GetChild (3).gameObject;

		spell4 = panel.transform.GetChild (2).transform.GetChild (0).transform.GetChild (0).gameObject;
		spell5 = panel.transform.GetChild (2).transform.GetChild (1).transform.GetChild (0).gameObject;
		button_spell4 = panel.transform.GetChild (2).transform.GetChild (2).gameObject;
		button_spell5 = panel.transform.GetChild (2).transform.GetChild (3).gameObject;
	}

	public void decrementSpellPt(){
		player.GetComponent<stats> ().spellsPt -= 1;
	}

	void displayButton(){

		if(spell0.GetComponent<spell0>().spellLVL < 5 && player.GetComponent<stats>().spellsPt > 0){
			button_spell0.SetActive(true);
		} else {
			button_spell0.SetActive(false);
		}
		if(spell1.GetComponent<spell1>().spellLVL < 5 && player.GetComponent<stats>().spellsPt > 0){
			button_spell1.SetActive(true);
		} else {
			button_spell1.SetActive(false);
		}
		if(spell2.GetComponent<spell2>().spellLVL < 5 && player.GetComponent<stats>().spellsPt > 0){
			button_spell2.SetActive(true);
		} else {
			button_spell2.SetActive(false);
		}
		if(spell3.GetComponent<spell3>().spellLVL < 5 && player.GetComponent<stats>().spellsPt > 0){
			button_spell3.SetActive(true);
		} else {
			button_spell3.SetActive(false);
		}
		if(spell4.GetComponent<spell4>().spellLVL < 5 && player.GetComponent<stats>().spellsPt > 0){
			button_spell4.SetActive(true);
		} else {
			button_spell4.SetActive(false);
		}
		if(spell5.GetComponent<spell5>().spellLVL < 5 && player.GetComponent<stats>().spellsPt > 0){
			button_spell5.SetActive(true);
		} else {
			button_spell5.SetActive(false);
		}

		button_spell0.transform.GetChild (0).GetComponent<Text> ().text = spell0.GetComponent<spell0> ().spellLVL.ToString ();
		button_spell1.transform.GetChild (0).GetComponent<Text> ().text = spell1.GetComponent<spell1> ().spellLVL.ToString ();
		button_spell2.transform.GetChild (0).GetComponent<Text> ().text = spell2.GetComponent<spell2> ().spellLVL.ToString ();
		button_spell3.transform.GetChild (0).GetComponent<Text> ().text = spell3.GetComponent<spell3> ().spellLVL.ToString ();
		button_spell4.transform.GetChild (0).GetComponent<Text> ().text = spell4.GetComponent<spell4> ().spellLVL.ToString ();
		button_spell5.transform.GetChild (0).GetComponent<Text> ().text = spell5.GetComponent<spell5> ().spellLVL.ToString ();
	}

	void displaySpell(){

		if (spell0.GetComponent<spell0> ().spellLVL <= 0) {
			spell0.SetActive (false);
		} else {
			spell0.SetActive (true);
		}
		if (spell1.GetComponent<spell1> ().spellLVL <= 0) {
			spell1.SetActive (false);
		} else {
			spell1.SetActive (true);
		}


		if (spell2.GetComponent<spell2> ().spellLVL <= 0) {
			spell2.SetActive (false);
		} else {
			spell2.SetActive (true);
		}
		if (spell3.GetComponent<spell3> ().spellLVL <= 0) {
			spell3.SetActive (false);
		} else {
			spell3.SetActive (true);
		}


		if (spell4.GetComponent<spell4> ().spellLVL <= 0) {
			spell4.SetActive (false);
		} else {
			spell4.SetActive (true);
		}
		if (spell5.GetComponent<spell5> ().spellLVL <= 0) {
			spell5.SetActive (false);
		} else {
			spell5.SetActive (true);
		}
	}

	void displayStep(){
		panel.SetActive (true);

		if (player.GetComponent<stats> ().level >= 6) {
			panel.transform.GetChild (0).gameObject.SetActive (true);
		} else {
			panel.transform.GetChild (0).gameObject.SetActive (false);
		}

		if (player.GetComponent<stats> ().level >= 12) {
			panel.transform.GetChild (1).gameObject.SetActive (true);
		} else {
			panel.transform.GetChild (1).gameObject.SetActive (false);
		}

		if (player.GetComponent<stats> ().level >= 18) {
			panel.transform.GetChild (2).gameObject.SetActive (true);
		} else {
			panel.transform.GetChild (2).gameObject.SetActive (false);
		}
		displaySpell ();
		displayButton ();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T) && panel.activeInHierarchy == false) {
			showPanel = true;
		} else if(Input.GetKeyDown (KeyCode.T) && panel.activeInHierarchy == true){
			panel.SetActive(false);
			showPanel = false;
		}
		if (showPanel) {
			displayStep();
		}
		panel.transform.GetChild (3).GetComponent<Text> ().text = "Spell Poitns : " + player.GetComponent<stats> ().spellsPt.ToString();
	}
}
