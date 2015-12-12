using UnityEngine;
using System.Collections;

public class Weapon_spawner : MonoBehaviour {

	public int level;
	public GameObject[] weapon;
	private GameObject drop;
	public bool build = false;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (build == false) {
			int y;
			
			y = Random.Range (0, weapon.Length);
			drop = Instantiate (weapon [y], transform.position, Quaternion.identity) as GameObject;
			drop.GetComponent<Weapon> ().item_level = level;
			build = true;
			Destroy(gameObject);
		}
	}
}
