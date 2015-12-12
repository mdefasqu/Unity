using UnityEngine;
using System.Collections;

public class fixCam : MonoBehaviour {

	public Camera fixedCam;
	public Camera flyCam;

	// Use this for initialization
	void Start () {
		fixedCam.enabled = false;
		flyCam.enabled = true;
	}

	public void SwitchCam(){
		fixedCam.enabled = !fixedCam.enabled;
		flyCam.enabled = !flyCam.enabled;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
