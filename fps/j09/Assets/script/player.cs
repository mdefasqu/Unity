using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public GameObject[] weapons;
	public int hp = 100;

	// Use this for initialization
	void Start () {
		weapons[0].SetActive(true);
		weapons[1].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("1") && weapons[1].GetComponent<weapon>().canFire){
			weapons[0].SetActive(true);
			weapons[1].SetActive(false);
		}
		if(Input.GetKeyDown("2") && weapons[0].GetComponent<weapon>().canFire){
			weapons[0].SetActive(false);
			weapons[1].SetActive(true);
		}
	}
}
