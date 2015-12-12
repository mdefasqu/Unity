using UnityEngine;
using System.Collections;

public class particle : MonoBehaviour {

	[HideInInspector] public int damage;

	void OnParticleCollision(GameObject other) {
		if (other.tag == "enemy") {
			other.GetComponent<enemy>().hp -= damage;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
