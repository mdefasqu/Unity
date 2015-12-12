using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class castBar : MonoBehaviour {

	[HideInInspector] public int globalCd = 0;
	[HideInInspector] public int cdSpell1 = 0;
	[HideInInspector] public int cdSpell2 = 0;
	[HideInInspector] public int cdSpell3 = 0;
	[HideInInspector] public int cdSpell4 = 0;

	private GameObject Cspell1;
	private GameObject Cspell2;
	private GameObject Cspell3;
	private GameObject Cspell4;
	private GameObject player;
	private GameObject focus;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void loadSpells(){
		if (transform.GetChild (5).transform.GetChild (0).transform.childCount > 0) {
			Cspell1 = transform.GetChild (5).transform.GetChild (0).transform.GetChild (0).gameObject;
		} else {
			Cspell1 = null;
		}
		if(transform.GetChild(5).transform.GetChild(1).transform.childCount > 0){
			Cspell2 = transform.GetChild(5).transform.GetChild(1).transform.GetChild(0).gameObject;
		} else {
			Cspell2 = null;
		}
		if(transform.GetChild(5).transform.GetChild(2).transform.childCount > 0){
			Cspell3 = transform.GetChild(5).transform.GetChild(2).transform.GetChild(0).gameObject;
		} else {
			Cspell3 = null;
		}
		if(transform.GetChild(5).transform.GetChild(3).transform.childCount > 0){
			Cspell4 = transform.GetChild(5).transform.GetChild(3).transform.GetChild(0).gameObject;
		} else {
			Cspell4 = null;
		}

	}

	IEnumerator resolveCD(int id, int cd, GameObject spell){

		spell.GetComponent<Image> ().color = Color.red;
		for(int i = cd; i > 0; i--){
			yield return new WaitForSeconds(1);
			if(id == 1){
				cdSpell1--;
			} else if(id == 2){
				cdSpell2--;
			} else if(id == 3){
				cdSpell3--;
			} else if(id == 4){
				cdSpell4--;
			}
		}
		spell.GetComponent<Image> ().color = Color.white;
	}
	
	void checkPassif(){
		if (Cspell1 != null && Cspell1.name == "spell1") {
			castSpell (Cspell1);
		} else if (Cspell2 != null && Cspell2.name == "spell1") {
			castSpell (Cspell2);
		} else if (Cspell3 != null && Cspell3.name == "spell1") {
			castSpell (Cspell3);
		} else if (Cspell4 != null && Cspell4.name == "spell1") {
			castSpell (Cspell4);
		} else {
			player.GetComponent<NavMeshAgent>().speed = 10;
		}
	}

	int castSpell(GameObject spell){

		int cd = 0;

		if (spell.name == "spell0" && focus != null) {
			cd = spell.GetComponent<spell0> ().Cast (focus, player);
		} else if (spell.name == "spell1") {
			cd = spell.GetComponent<spell1> ().Cast (focus, player);
		} else if (spell.name == "spell2") {
			cd = spell.GetComponent<spell2> ().Cast (focus, player);
		} else if (spell.name == "spell3") {
			cd = spell.GetComponent<spell3> ().Cast (focus, player);
		} else if (spell.name == "spell4") {
			cd = spell.GetComponent<spell4> ().Cast (focus, player);
		} else if (spell.name == "spell5") {
			cd = spell.GetComponent<spell5> ().Cast (focus, player);
		}

		return cd;
	}

	// Update is called once per frame
	void Update () {

		loadSpells ();

		Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (cursorRay.origin, cursorRay.direction, out hit, 200)) {
			if (hit.collider.tag == "Enemy") {
				focus = hit.collider.gameObject;
			} else {
				focus = null;
			}
		} else {
			focus = null;
		}

		checkPassif();
		

		if(Input.GetKeyDown("1") && cdSpell1 == 0 && globalCd == 0 && Cspell1 != null){
			cdSpell1 = castSpell(Cspell1);
			StartCoroutine(resolveCD(1, cdSpell1, Cspell1));
		} else if (Input.GetKeyDown("2") && cdSpell2 == 0 && globalCd == 0 && Cspell2 != null){
			cdSpell2 = castSpell(Cspell2);
			StartCoroutine(resolveCD(2, cdSpell2, Cspell2));
		} else if (Input.GetKeyDown("3") && cdSpell3 == 0 && globalCd == 0 && Cspell3 != null){
			cdSpell3 = castSpell(Cspell3);
			StartCoroutine(resolveCD(3, cdSpell3, Cspell3));
		} else if (Input.GetKeyDown("4") && cdSpell4 == 0 && globalCd == 0 && Cspell4 != null){
			cdSpell4 = castSpell(Cspell4);
			StartCoroutine(resolveCD(4, cdSpell4, Cspell4));
		}
	}
}
