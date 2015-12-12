using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	private bool cooldown = false;
	// Use this for initialization
	void Start () {
	
	}

	IEnumerator	Delai() {
		cooldown = true;
		yield return new WaitForSeconds (0.1f);
		cooldown = false;
	}

	void OnTriggerStay(Collider collider) {
		if (collider.tag == "Player" && cooldown == false) {
			collider.GetComponent<stats>().life -= 7;
			StartCoroutine(Delai());
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0.2f, 0);
	}
}
