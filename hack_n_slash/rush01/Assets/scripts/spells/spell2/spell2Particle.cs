using UnityEngine;
using System.Collections;

public class spell2Particle : MonoBehaviour {

	private bool isActive = false;
	private bool dealDamage = true;

	[HideInInspector] public int damage = 0;

	IEnumerator DealDamage(){
		dealDamage = false;
		var hitColliders = Physics.OverlapSphere (transform.position, 10);
		
		for (var i = 0; i < hitColliders.Length; i++) {
			if (hitColliders [i].tag == "Enemy") {
				hitColliders [i].gameObject.GetComponent<stats>().takeDamage(damage);
			}
		}
		yield return new WaitForSeconds (1);
		dealDamage = true;
	}

	IEnumerator autoDestroy(){
		yield return new WaitForSeconds (10);
		Destroy (gameObject);
	}

	public void ActiveSpell(){
		isActive = true;
		StartCoroutine (autoDestroy ());
	}

	// Update is called once per frame
	void Update () {

		if (isActive && dealDamage) {
			StartCoroutine (DealDamage ());
		}
	}
}
