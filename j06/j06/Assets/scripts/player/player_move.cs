using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour {
	
	public float playerSpeed = 10;
	public AudioSource walk;

	private int sprint = 1;




	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			sprint = 2;
			walk.Play();
			walk.loop = true;
		} 
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			sprint = 1;
			walk.Stop();
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
			transform.Translate(-Vector3.right * (playerSpeed * Time.deltaTime) * sprint);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector3.right * (playerSpeed * Time.deltaTime) * sprint);
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			transform.GetChild (0).gameObject.SetActive (!transform.GetChild(0).gameObject.activeInHierarchy);
		}
	}
	
	void Start ()
	{
		transform.GetChild (0).gameObject.SetActive (false);
	}
}