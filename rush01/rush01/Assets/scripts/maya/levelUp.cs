using UnityEngine;
using System.Collections;

public class levelUp : MonoBehaviour {

	public GameObject effect;
	private GameObject temp;

	IEnumerator autoDestroy(GameObject spell){
		yield return new WaitForSeconds (5);
		Destroy (spell);
	}

	public void PlayerLevelUp(){
		int pourcent;
		if (GetComponent<stats> ().level >= 50) {
			pourcent = 100;
		} else {
			pourcent = 125;
		}
		
		GetComponent<stats> ().level += 1;
		GetComponent<stats> ().xp = GetComponent<stats> ().xp - GetComponent<stats> ().xpToUp;
		GetComponent<stats> ().xpToUp = ((GetComponent<stats> ().xpToUp * pourcent) / 100);
		GetComponent<stats> ().life = GetComponent<stats> ().hp;
		GetComponent<stats> ().skills += 5;
		if(GetComponent<stats> ().level > 5)
			GetComponent<stats> ().spellsPt += 1;
		temp = Instantiate (effect, transform.position, Quaternion.identity) as GameObject;
		StartCoroutine (autoDestroy (temp));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
