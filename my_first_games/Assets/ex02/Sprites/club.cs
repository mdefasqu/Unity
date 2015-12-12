using UnityEngine;
using System.Collections;

public class club : MonoBehaviour {


	private float x_start;
	private int space;
	private int sign;
	// Use this for initialization
	void Start () {
		x_start = transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.y >= 6)
			sign = -1;
		else
			sign = 1;
		if (Input.GetKey ("space")) {
			transform.Translate (0, -0.1F* sign, 0);
			x_start += 0.1F * sign;
			space = 1;
		} else if ((x_start > 0.1F || x_start < -0.1F) && space == 1) {
			transform.Translate (0, x_start / 3, 0);
			x_start -= x_start / 3;
		} else if (x_start < 0.1F && space == 1) {
			x_start = 0;
			space = 0;
			//GameObject.Destroy(gameObject);
		}
	}
}
