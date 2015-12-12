using UnityEngine;
using System.Collections;

public class ring_rb : MonoBehaviour {

	IEnumerator blink() {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		for (int i = 0; i < 25; i++) {
			sr.color = Color.clear;
			yield return new WaitForSeconds(0.1f);
			sr.color = Color.white;
			yield return new WaitForSeconds(0.1f);
			Debug.Log ("aie");
		}
	}

	IEnumerator depop() {
		for (int i = 0; i < 6; i++) {
			if(i==2){
				StartCoroutine(blink());
			}
			yield return new WaitForSeconds(1);
			Debug.Log ("aie");
		}
		Destroy (gameObject);
	}


	void Awake() {

	}
	// Use this for initialization
	void Start () {
		StartCoroutine(depop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
