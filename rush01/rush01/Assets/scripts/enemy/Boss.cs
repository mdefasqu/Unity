using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour {

	private GameObject player;
	private bool Begin_spawn;
	private bool Begin_spawn_turret;
	public GameObject enemySpawner;
	public GameObject TurretSpawner;
	private List<GameObject> obj = new List<GameObject>();
	private List<GameObject> turret = new List<GameObject>();
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	IEnumerator summon_spawner() {
		Begin_spawn = true;
		yield return new WaitForSeconds (10);
		Begin_spawn = false;
		Debug.Log("spwannow");
		obj.Add(Instantiate (enemySpawner, transform.position, Quaternion.identity)as GameObject);
	}

	IEnumerator summon_spawner_turret() {
		Begin_spawn_turret = true;
		yield return new WaitForSeconds (12);
		Begin_spawn_turret = false;
		Debug.Log("spwannow");
		turret.Add(Instantiate (TurretSpawner, transform.position, Quaternion.identity)as GameObject);
	}

	void clear_spawn() {
		for (int i = 0; i < obj.Count; i++){
				Destroy (obj[i].gameObject);
				obj.RemoveAt(i);
		}
		for (int y = 0; y < turret.Count; y++){
			Destroy (turret[y].gameObject);
			turret.RemoveAt(y);
		}
	}
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) < GetComponent<enemy>().aggroRange && Begin_spawn == false && GetComponent<stats> ().life > 0) {
			StartCoroutine(summon_spawner());
		}
		if (Vector3.Distance (transform.position, player.transform.position) < GetComponent<enemy>().aggroRange && Begin_spawn_turret == false && GetComponent<stats> ().life > 0) {
			StartCoroutine(summon_spawner_turret());
		}
		if (GetComponent<stats> ().life <= 0) {
			clear_spawn ();
			Begin_spawn = true;
		}
	}	
}
