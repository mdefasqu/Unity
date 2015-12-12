using UnityEngine;
using System.Collections;

public class pan : MonoBehaviour {

	private bool change = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.y > 0.995f && change == true)
			change = false;
		if (transform.rotation.y < 0.86f && change == false)
			change = true;


		if (change) {
			transform.Rotate (0, 0.2F, 0);
		}
		else {
			transform.Rotate (0, -0.2F, 0);
		}
	}
}
