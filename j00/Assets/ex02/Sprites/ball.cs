using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	public GameObject club;

//	private float start_x;
	private float force;
	public GameObject go;
	public int sign;
	private float max_force;
	private float y;
	private int shot;
	private int pos;
	private int score;
	// Use this for initialization
	void Start () {
		sign = 1;
		score = -15;
		shot = 0;
		pos = 0;
		y = 0;
		//start_x = transform.localPosition.x;
		Vector3 newPos = new Vector3 (transform.localPosition.x - 0.3F, transform.localPosition.y, transform.localPosition.z);
		if (!go) {
			go = Instantiate (club, newPos, Quaternion.identity) as  GameObject;
		}
	}

	void displayScore()
	{
		this.score += 5;
		if (this.score == 0) {
			Debug.Log ("Score: "+this.score);
			Debug.Log ("You loose !");
		}
		else {
			Debug.Log ("Score: "+this.score);
		}
	}

	void Update () {
		if (transform.localPosition.x == 0) {
			if (Input.GetKey ("space") && shot == 0) {
				force += 0.1F;
				max_force = 1;
				if (y == 0)
					y = transform.localPosition.y;
			} else if (force > 0.01F) {
				shot = 1;
				transform.Translate (0, force * sign, 0);
				force = force / 1.05F;
				if (transform.localPosition.y <= 5 && transform.localPosition.y >= 4 && force <= 0.08F) {
					go.transform.Translate (-1000, 0, 0);
					transform.Translate (-1000, 0, 0);
					if(score < 0){
						Debug.Log ("Score: "+ score);
						Debug.Log ("You Win !");
					}
				} 
				if (transform.localPosition.y >= 6.40) {	
					sign = -1;
				} else if (transform.localPosition.y <= -6.5) {
					sign = 1;
				}
			} else if (force <= 0.1F) {
				force = 0;
				shot = 0;

				if (transform.localPosition.y >= 4.65)
					pos = 2;
				else
					pos = 0;
				if (max_force != 0) {
					go.transform.Translate (0, pos + transform.localPosition.y - go.transform.localPosition.y, 0);
					this.displayScore();
					max_force = 0;
					y = 0;
				}
				if (transform.localPosition.y < 4.72)
					sign = 1;
				else {
					sign = -1;
				}

			}
		}
	}
}
