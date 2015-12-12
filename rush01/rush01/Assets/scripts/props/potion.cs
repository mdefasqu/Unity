using UnityEngine;
using System.Collections;

public class potion : MonoBehaviour {

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			other.GetComponent<stats>().life += (other.GetComponent<stats>().hp * 30 )/100;
			Destroy(gameObject);
		}
	}
}

