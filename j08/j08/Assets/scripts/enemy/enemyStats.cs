using UnityEngine;
using System.Collections;

public class enemyStats : MonoBehaviour {
	
	void Start () {
	}
	
	void Update () {
		if(GetComponent<stats>().life <= 0 && GetComponent<stats>().isDie == false) {
			Debug.Log ("ENEMY MORT");
			GetComponent<Animator>().SetTrigger("die");
			GetComponent<NavMeshAgent>().enabled = false;
			GetComponent<CapsuleCollider>().enabled = false;
			GetComponent<stats>().isDie = true;
		}
	}
}
