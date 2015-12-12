using UnityEngine;
using System.Collections;

public class autoDestroy : MonoBehaviour {

	IEnumerator selfDestroy()
	{
		for (int i = 0; i < 3; i++) {
			yield return new WaitForSeconds(1);
		}
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (selfDestroy());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
