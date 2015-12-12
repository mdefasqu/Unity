using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public static gameManager gm;
	public int player_force;
	public int club_strength;

	public GameObject ball;
	public GameObject flyCamera;
	public GameObject fixCamera;
	public GameObject panelPower;
	public bool isFocus = true;
	public bool isInAir = false;

	void Awake () {
		if (gm == null)
			gm = this;
	}
	// Use this for initialization
	void Start () {
	
	}

	IEnumerator Stop_ball(){
		for(int i = 0; i < 1; i++){
			yield return new WaitForSeconds(10);
		}
		isFocus = true;
		isInAir = false;
		fixCamera.transform.position = ball.transform.position;
		fixCamera.GetComponent<fix_camera>().SwitchCam();
		panelPower.transform.GetChild(0).transform.GetChild(0).transform.localScale = new Vector3 (panelPower.transform.GetChild(0).transform.GetChild(0).transform.localScale.x, 0, panelPower.transform.GetChild(0).transform.GetChild(0).transform.localScale.z);
	}

	void shoot(){

		if (Input.GetKeyDown (KeyCode.Space) && !GetComponent<power>().shooting && isFocus == true) {
			GetComponent<power>().shooting = true;
		} else if (Input.GetKeyDown (KeyCode.Space) && GetComponent<power>().shooting && isFocus == true) {
			GetComponent<power>().shooting = false;

			Vector3 direction = fixCamera.transform.GetChild(0).transform.right * club_strength;
			direction.y = player_force * (GetComponent<power>().power_value + 1);
			ball.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
			isFocus = false;
			fixCamera.GetComponent<fix_camera>().SwitchCam();
			isInAir = true;
			StartCoroutine(Stop_ball());
		}
	}

	// Update is called once per frame
	void Update () {

		if (ball.GetComponent<Rigidbody> ().IsSleeping ()) {
			Debug.Log ("sleeping");
		} else {
			Debug.Log ("not sleeping");
		}

		if (isFocus == true) {
			ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			panelPower.SetActive(true);

		} else {
			panelPower.SetActive(false);
		}

		shoot ();
	}
}

//jauge.transform.localScale += new Vector3 (0, -0.05F, 0);
//Quaternion rotation = Quaternion.Euler(xAngle, yAngle, zAngle);
//Vector3 direction = rotation * Vector3.forward;
//shot_bullet.GetComponent<Rigidbody2D> ().velocity = hero.transform.right * bullet_speed;