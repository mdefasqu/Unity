using UnityEngine;
using System.Collections;

public class life : MonoBehaviour {

	public int nbLife;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (gameObject.name + " : " + nbLife);
		if (nbLife <= 0) {
			if(gameObject.name == "canon"){
				Application.LoadLevel(Application.loadedLevel);
			} else {
				gameObject.transform.position = new Vector3(-1000, -1000, -1000);
			}
		}
	}
}
