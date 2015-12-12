using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public GameObject[] enemies;
	public int minTimeSpawn = 0;
	public int maxTimeSpawn = 10;


	public int aggroRange = 12;
	public int attackRange = 2;
	public int runSpeed = 10;
	public int attackDamage;
	
	public int hp = 1;

	private GameObject[] destinations;
	private GameObject player;
	private bool canSpawn = true;
	// Use this for initialization


	void initMob(GameObject mob){
		mob.GetComponent<enemy> ().aggroRange = aggroRange;
		mob.GetComponent<enemy> ().attackRange = attackRange;
		mob.GetComponent<enemy> ().runSpeed = runSpeed;
		mob.GetComponent<enemy> ().attackDamage = attackDamage;
		mob.GetComponent<enemy> ().dest = destinations [Random.Range (0, destinations.Length)];
		mob.GetComponent<enemy> ().player = player;
		mob.GetComponent<enemy> ().hp = hp;
	}

	IEnumerator spawnMob(int time){
		canSpawn = false;
		GameObject mob;
		mob = Instantiate (enemies [Random.Range (0, enemies.Length)], transform.position, Quaternion.identity) as GameObject;
		initMob (mob);
		yield return new WaitForSeconds (time);
		canSpawn = true;
	}

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		destinations = GameObject.FindGameObjectsWithTag ("dest");
	}
	
	// Update is called once per frame
	void Update () {
		if (canSpawn) {
			StartCoroutine(spawnMob(Random.Range(minTimeSpawn, maxTimeSpawn)));
		}
	}
}


