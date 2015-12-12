using UnityEngine;
using System.Collections;

public class playerScript_ex00 : MonoBehaviour {

	public float jump_speed = 500;
	public float movementSpeed = 5.0f;
	private float js;

	private bool isGrounded = true;

	// Use this for initialization
	void Start () {
		this.js = 0;
	}

	void jump()
	{
		isGrounded = false;
		gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector3(0, jump_speed,0), ForceMode2D.Force);
	}

	void left()
	{
		if (Input.GetKey ("d")) {
			transform.position -= Vector3.left * movementSpeed * Time.deltaTime;
			//gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector3(0.9f, 0,0), ForceMode2D.Impulse);
		}
	}

	void right()
	{
		if (Input.GetKey ("a")) {
			transform.position -= Vector3.right * movementSpeed * Time.deltaTime;
			//gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector3(-1.5f, 0,0), ForceMode2D.Impulse);
		}
	}
	public Vector3 move()
	{
		if (Input.GetKeyDown ("space") && isGrounded) {
			jump ();
		}
		left ();
		right ();
		return new Vector3 (transform.position.x, transform.position.y, -1);
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
//		if (other.gameObject.tag == "ground" 
//		    || other.gameObject.tag == "Thomas" 
//		    || other.gameObject.tag == "John"
//		    || other.gameObject.tag == "Claire") {
//			isGrounded = true;
//		}
		if (other.gameObject.tag != "wall") {
			isGrounded = true;
		}
	}

}
