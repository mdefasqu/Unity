using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {

	public GameObject john;
	public GameObject claire;
	public GameObject thomas;
	private GameObject active;
	// Use this for initialization

	void Update_player(GameObject player)
	{
		Vector3 pos;
		pos = player.GetComponent<playerScript_ex00> ().move ();
		Camera.main.transform.position =  pos;
	}

	void Start () {
		active = john;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown("1")){
			active = john;
		}
		else if(Input.GetKeyDown("2")){
			active = claire;
		}
		else if(Input.GetKeyDown("3")){
			active = thomas;
		}
		Update_player (active);
	}
}
