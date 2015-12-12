using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	private int letter;
	private float dist;
	private float vitesse;


	// Use this for initialization
	void Start () {
		vitesse = Random.Range (0.1F, 0.3F);
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (0, -vitesse, 0);
		dist += vitesse;
		if(Input.GetKeyDown ("a") && transform.localPosition.x == -4.44F)
		{
			Debug.Log("Precision: "+dist);
			GameObject.Destroy(gameObject);
		}
		if(Input.GetKeyDown ("s") && transform.localPosition.x == 0)
		{
			Debug.Log("Precision: "+dist);
			GameObject.Destroy(gameObject);
		}
		if(Input.GetKeyDown ("d") && transform.localPosition.x == 4.44F)
		{
			Debug.Log("Precision: "+dist);
			GameObject.Destroy(gameObject);
		}
		if (dist >= 8.5F) 
		{
			Debug.Log("Fail !");
			GameObject.Destroy(gameObject);
		}
	}
}
