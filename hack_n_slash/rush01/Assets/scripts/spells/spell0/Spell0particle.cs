using UnityEngine;
using System.Collections;

public class Spell0particle : MonoBehaviour {

	[HideInInspector] public int damage = 10;

	void OnParticleCollision(GameObject other){
		if (other.tag == "Enemy") {
			other.GetComponent<stats>().life -= damage;
		}
	}
}
