using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	// Use this for initialization

	[HideInInspector] public string owner;

	void destroy_bullet()
	{
		Destroy (gameObject);
	}

	void Start () {
		Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite.name);
		if (gameObject.GetComponent<SpriteRenderer> ().sprite.name == "5") {
			Debug.Log ("mouhahaha");
			Invoke("destroy_bullet", 0.15f);
		} else {
			Invoke ("destroy_bullet", 4);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "decor") {
			Destroy (gameObject);
		}
		if (collider.gameObject.tag == "hero") {
			if(collider.gameObject.GetComponent<hero>().isWin == false){
				collider.gameObject.GetComponent<hero>().die();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.tag == "enemy") {
			Destroy (gameObject);
			if(owner == "hero")
				collider.gameObject.GetComponent<enemy>().die();
		}
		if (collider.gameObject.tag == "decor") {
			Destroy (gameObject);
		}
	}


	void OnControllerColliderHit(ControllerColliderHit hit){
	}

	// Update is called once per frame
	void Update () {
		
	}
}
