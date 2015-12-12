using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class refreshUI : MonoBehaviour {

	Text currentXP;
	Text targetXP;
	Text level;
	Text life;
	GameObject xpBar;
	GameObject lifeBar;
	GameObject player;

	GameObject FlifeBar;
	Text Flife;
	Text Flvl;
	Text Fname;


	float Pourcentage(int current, int max){
		float result = (current * 100) / max;
		result = result / 100;
		return (result);
	}

	// Use this for initialization
	void Start () {
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
	}



	// Update is called once per frame
	void Update () {
		bool touch = false;

		xpBar.transform.localScale = new Vector3 (Pourcentage (player.GetComponent<stats>().xp, player.GetComponent<stats>().xpToUp), 1, 1);
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
			}
		}

		if (player.GetComponent<attack> ().focusEnemy != null || touch) {
			GameObject focus;
			transform.GetChild(3).gameObject.SetActive(true);

			if (touch) {
				focus = hit.collider.gameObject;
			} else {
				focus = player.GetComponent<attack> ().focusEnemy;
			}

			if (focus != null) {
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