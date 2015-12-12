using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class discretion : MonoBehaviour {

	[HideInInspector]public bool gameOver = false;
	public int alertLvl = 1;
	public GameObject jauge;
	public AudioSource alarm;
	public AudioSource normal;
	public AudioSource detect;
	public Text trick;
	private bool inLight = false;

	public bool pass = false;
	public bool isOver = false;

	IEnumerator displayTrick(string str)
	{
		trick.text = str;
		float color = 0;
		for(int i = 0; i <= 50; i++){
			if(i < 25){
				color += 0.04f;
				trick.color = new Color(1, 1, 1, color);
			}
			else{
				color -= 0.04f;
				trick.color = new Color(1, 1, 1, color);
			}
			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator youWin(){
		gameObject.GetComponent<fixCam> ().SwitchCam ();
		StartCoroutine (displayTrick ("GG"));
		for (int i = 0; i < 1; i++) {
			yield return new WaitForSeconds(3);
		}
		Application.LoadLevel (Application.loadedLevel);
	}

	IEnumerator youLoose(){
		gameObject.GetComponent<fixCam> ().SwitchCam ();
		StartCoroutine (displayTrick ("You Loose"));
		for (int i = 0; i < 1; i++) {
			yield return new WaitForSeconds(3);
		}
		Application.LoadLevel (Application.loadedLevel);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "light") {
			inLight = true;
			alarm.Play ();
			detect.Play ();
			normal.Stop ();
		} else if (other.tag == "camera") {
			alarm.Play ();
			detect.Play ();
			normal.Stop ();
			inLight = true;
			alertLvl = 3;
		}
		if (other.tag == "fan") {
			StartCoroutine (displayTrick ("Presse E pour casser la ventilation"));
		}
		if (other.tag == "pass")
			StartCoroutine(displayTrick("Presse E pour ramasser le pass"));
		if (other.tag == "console") {
			if (pass){
				StartCoroutine(displayTrick("Presse E pour ouvrir la porte"));
			} else {
				StartCoroutine(displayTrick("Trouve le pass"));
			}
		}
		if (other.tag == "papier") {
			StartCoroutine (displayTrick ("Presse E pour recuperer les sujets"));
		}
	}


	void OnTriggerStay(Collider other){
		if (other.tag == "pass") {
			if (Input.GetKeyDown (KeyCode.E)) {
				pass = true;
				Destroy (other.gameObject);
			}
		}
		if (other.tag == "console") {
			if (Input.GetKeyDown (KeyCode.E) && pass == true) {
				pass = false;
				other.GetComponent<openDoor>().open();
			} 
		}
		if (other.tag == "papier") {
			if (Input.GetKeyDown (KeyCode.E)) {
				StartCoroutine(youWin());
			}
		}
		if(other.tag == "fan"){
			if (Input.GetKeyDown (KeyCode.E)){
				other.GetComponent<fan>().activeSmoke();
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "light") {
			inLight = false;
			alarm.Stop();
			detect.Stop();
			normal.Play();
		} else if (other.tag == "camera") {
			alarm.Stop();
			detect.Stop();
			normal.Play();
			inLight = false;
			alertLvl = 1;
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(displayTrick("Recupere les sujets du jour"));
		normal.Play ();
		jauge.transform.GetChild(0).transform.localScale = new Vector3 (0, 1, 0);
		jauge.transform.GetChild(1).transform.localScale = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (gameOver && !isOver) {
			isOver = true;
			StartCoroutine(youLoose());
		}
		if (inLight) {
			if (jauge.transform.GetChild (0).transform.localScale.x <= 1) {
				jauge.transform.GetChild (0).transform.localScale += new Vector3 (0.0051f * alertLvl, 0, 0);
			} else if (jauge.transform.GetChild (1).transform.localScale.x <= 1) {
				jauge.transform.GetChild (1).transform.localScale += new Vector3 (0.015f * alertLvl, 0, 0);
			}
			if (jauge.transform.GetChild (1).transform.localScale.x >= 1) {
				gameOver = true;
			}
		} else {
				if (jauge.transform.GetChild (0).transform.localScale.x > 0 && jauge.transform.GetChild (1).transform.localScale.x <= 0) {
					jauge.transform.GetChild (0).transform.localScale += new Vector3 (-0.01f, 0, 0);
				}
				if (jauge.transform.GetChild (1).transform.localScale.x > 0) {
					jauge.transform.GetChild (1).transform.localScale += new Vector3 (-0.03f, 0, 0);
				}
		}
	}
}
