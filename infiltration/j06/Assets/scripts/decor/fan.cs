using UnityEngine;
using System.Collections;

public class fan : MonoBehaviour {
	
	public GameObject triggerCam;

	public void activeSmoke()
	{
		Debug.Log ("Active smoke");
		transform.GetChild (1).GetComponent<ParticleSystem> ().enableEmission = true;
		triggerCam.transform.gameObject.tag = "light";
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("off");
		transform.GetChild (1).GetComponent<ParticleSystem> ().enableEmission = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
