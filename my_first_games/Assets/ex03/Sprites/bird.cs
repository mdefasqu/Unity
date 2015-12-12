using UnityEngine;
using System.Collections;

public class bird : MonoBehaviour {

	private float y_pos;
	private float gravity;
	private int die_val;

	public GameObject pipe_system;

	void 	increase()
	{
		this.gravity = 0;
		transform.Translate (0, this.y_pos, 0);
		this.y_pos = this.y_pos / 1.1F;
		if (this.y_pos < 0.01F) {
			this.y_pos = 0;
		}
	}

	void 	decrease()
	{
		transform.Translate (0, -0.1F * this.gravity, 0);
		this.gravity = this.gravity + 0.1f;
	}

	public void 	die()
	{
		this.die_val = 1;
	}
	
	// Use this for initialization
	void Start () {
		this.gravity = 0.5F;
		this.die_val = 0;
	}


	// Update is called once per frame
	void Update () {
		if (die_val == 0) {
			if (Input.GetKeyDown ("space")) {
				this.y_pos = 0.2F;
			}
		}
		if (this.y_pos != 0) {
			this.increase();
		}
		else {
			this.decrease();
		}
	}
}
