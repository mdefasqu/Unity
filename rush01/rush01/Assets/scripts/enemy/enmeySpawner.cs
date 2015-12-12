using UnityEngine;
using System.Collections;

public class enmeySpawner : MonoBehaviour {

	public GameObject[] Enemys;
	public int repopTime;

	private GameObject current;
	private GameObject player;
	private bool repop = false;

	private void setStats(GameObject current){
		int pourcent = 50;
		int Plvl = player.GetComponent<stats> ().level;

		current.GetComponent<stats> ().Strengh += ((current.GetComponent<stats> ().Strengh * pourcent) / 100) * Plvl;
		current.GetComponent<stats> ().Agility += ((current.GetComponent<stats> ().Agility * pourcent) / 100) * Plvl;
		current.GetComponent<stats> ().Constitution += ((current.GetComponent<stats> ().Constitution * pourcent) / 100) * Plvl;
		current.GetComponent<stats> ().xp += ((current.GetComponent<stats> ().xp * pourcent) / 100) * Plvl;
		current.GetComponent<stats> ().level = player.GetComponent<stats> ().level;
	}


	IEnumerator startRepop(int time){
		repop = true;
		yield return new WaitForSeconds(time);
		current = Instantiate (Enemys [Random.Range (0, Enemys.Length)], transform.position - new Vector3(0, 4 ,0), Quaternion.identity) as GameObject;
		setStats (current);
		current.GetComponent<CapsuleCollider> ().enabled = false;
		current.GetComponent<enemy> ().isPoping = true;
		current.GetComponent<NavMeshAgent> ().enabled = false;
		for(int i = 0; i < 100; i++) {
			current.transform.Translate(new Vector3(0, 0.03F, 0));
			yield return new WaitForSeconds(0.01f);
		}
		current.GetComponent<enemy> ().isPoping = false;
		current.GetComponent<NavMeshAgent> ().enabled = true;
		current.GetComponent<CapsuleCollider> ().enabled = true;
		repop = false;
	}
	// Use this for initialization
	void Start () {
		//current = Instantiate (Enemys [Random.Range (0, Enemys.Length)], transform.position, Quaternion.identity) as GameObject;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (!current && repop == false) {
			StartCoroutine(startRepop(repopTime));
		}
	}
}