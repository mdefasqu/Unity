using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject[]letters;

	private float spawnTime;
	private float timer;
	private int rand;
	private Vector3 newPos;
	private GameObject go_a;
	private GameObject go_s;
	private GameObject go_d;


	void Update () {
		spawnTime = Random.Range (0.1F, 4);
		if (timer >= spawnTime) {
			timer = 0;
			rand = Random.Range(0,3);
			if(rand == 0)
				newPos = new Vector3 (-4.44F, 4.25F, 0);
			else if(rand == 1)
				newPos = new Vector3 (4.44F, 4.25F, 0);
			else
				newPos = new Vector3 (0, 4.25F, 0);
			if (rand == 0 && !go_a)
				go_a = Instantiate(letters[rand], newPos, Quaternion.identity) as GameObject;
			if (rand == 2 && !go_s)
				go_s = Instantiate(letters[rand], newPos, Quaternion.identity) as GameObject;
			if (rand == 1 && !go_d)
				go_d = Instantiate(letters[rand], newPos, Quaternion.identity) as GameObject;
		}
		timer += Time.deltaTime;

	}
}





