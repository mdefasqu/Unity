using UnityEngine;
using System.Collections;

public class fix_camera : MonoBehaviour {

	public Camera fixCam;
	public Camera flyCam;

	// Use this for initialization
	void Start () {
		fixCam.enabled = true;
		flyCam.enabled = false;
	}

	public void SwitchCam(){
		fixCam.enabled = !fixCam.enabled;
		flyCam.enabled = !flyCam.enabled;
	}

	void moveFix(){
		if(gameManager.gm.isFocus == true){
			if(Input.GetKey(KeyCode.A)){
				Vector3 temp = transform.rotation.eulerAngles;
				temp.y += 1f;
				transform.rotation = Quaternion.Euler(temp);
				transform.rotation = Quaternion.Euler(temp);
			}
			if(Input.GetKey(KeyCode.D)){
				Vector3 temp = transform.rotation.eulerAngles;
				temp.y -= 1f;
				transform.rotation = Quaternion.Euler(temp);
				transform.rotation = Quaternion.Euler(temp);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C) && gameManager.gm.isInAir == false) {
			SwitchCam();
			gameManager.gm.isFocus = !gameManager.gm.isFocus;
		}
		moveFix ();
	}
}
