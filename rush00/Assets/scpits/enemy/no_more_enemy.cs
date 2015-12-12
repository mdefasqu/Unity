using UnityEngine;
using System.Collections;

public class no_more_enemy : MonoBehaviour {

	private bool win_send;
	private GameObject hero;
	// Use this for initialization
	void Start () {
		hero = GameObject.FindGameObjectWithTag ("hero");
		win_send = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount == 0 && win_send == false && hero.GetComponent<hero>().isDie == false) {
			win_send = true;
			hero.GetComponent<hero>().display_win(true);
			if(PlayerPrefs.GetInt("last_level") <= Application.loadedLevel){
				PlayerPrefs.SetInt("last_level", Application.loadedLevel + 1);
				Debug.Log ("ADD");
			}
		}
	}
}