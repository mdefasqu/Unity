using UnityEngine;
using System.Collections;

public class chenilles : MonoBehaviour {

	int sprint = 1;
	int angle = 0;
	public int playerSpeed = 10;

	private bool canSprint = true;


	IEnumerator goSprint(){
		sprint = 2;
		canSprint = false;
		for (int i = 0; i < 10; i++) {
			if (i == 4)
				sprint = 1;
			yield return new WaitForSeconds(1);
		}
		canSprint = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift) && canSprint) {
			StartCoroutine(goSprint());
		} 
		move_key ();
	}
	
	void move_key(){
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(Vector3.forward * (playerSpeed * Time.deltaTime) * sprint);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate(-Vector3.forward * (playerSpeed * Time.deltaTime) * sprint);
		}
		if (Input.GetKey (KeyCode.A)) {
			angle -= playerSpeed / 4;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		}
		if (Input.GetKey (KeyCode.D)) {
			angle += playerSpeed / 4;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			transform.rotation = Quaternion.AngleAxis(0, Vector3.right);
		}
	}
}
