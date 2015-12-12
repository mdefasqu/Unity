using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class fly_camera : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;
	public float translateSpeed = 1;

	float rotationY = 0F;

	private bool touch = false;

	void OnCollisionEnter(Collision collision) {
		touch = true;
	}

	void OnCollisionExit(Collision collision) {
		Debug.Log ("exit");
		touch = false;

	}

	void Update ()
	{

		if (touch) {
			touch = false;
		}

		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
		move_key ();
	}

	void move_key(){

		if (gameManager.gm.isFocus == false) {
			if (Input.GetKey (KeyCode.W)) {
				if (touch == false) {
					transform.Translate (new Vector3 (0, 0, translateSpeed * Time.deltaTime));
				} else {
					transform.Translate (new Vector3 (0, 0, -translateSpeed * Time.deltaTime));
				}
			}
		
			if (Input.GetKey (KeyCode.S)) {
				if (touch == false) {
					transform.Translate (new Vector3 (0, 0, -translateSpeed * Time.deltaTime));
				} else {
					transform.Translate (new Vector3 (0, 0, translateSpeed * Time.deltaTime + 2));
				}
			}
			if (Input.GetKey (KeyCode.A)) {
				if (touch == false) {
					transform.Translate (new Vector3 (-translateSpeed * Time.deltaTime, 0, 0));
				} else {
					transform.Translate (new Vector3 (translateSpeed * Time.deltaTime + 2, 0, 0));

				}
			}
		
			if (Input.GetKey (KeyCode.D)) {
				if (touch == false) {
					transform.Translate (new Vector3 (translateSpeed * Time.deltaTime, 0, 0));
				} else {
					transform.Translate (new Vector3 (-translateSpeed * Time.deltaTime + 2, 0, 0));
				}
			}
		
		
			if (Input.GetKey (KeyCode.Q)) {
				if (touch == false) {
					transform.Translate (new Vector3 (0, -translateSpeed * Time.deltaTime, 0));
				} else {
					transform.Translate (new Vector3 (0, translateSpeed * Time.deltaTime, 0));
				}
			}
		
			if (Input.GetKey (KeyCode.E)) {
				if (touch == false) {
					transform.Translate (new Vector3 (0, translateSpeed * Time.deltaTime, 0));
				} else {
					transform.Translate (new Vector3 (0, -translateSpeed * Time.deltaTime + 2, 0));
				}
			}
			if (transform.position.y >= 80) {
				transform.position = new Vector3 (transform.position.x, transform.position.y - 2, transform.position.z);
			}
		}
	}

	void Start ()
	{
	}
}