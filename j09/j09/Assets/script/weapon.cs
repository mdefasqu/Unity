using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public float attackSpeed = 1f;
	public int damage = 5;
	public int damageArea = 0;

	public AudioSource fire;
	public ParticleSystem bullet;

	[HideInInspector] public bool canFire;

	// Use this for initialization

	IEnumerator shoot(){
		canFire = false;
		bullet.Emit (1);
		yield return new WaitForSeconds (attackSpeed);
		canFire = true;
	}

	void Start () {
		canFire = true;
		transform.GetChild (0).transform.GetChild (1).transform.GetChild (0).GetComponent<particle> ().damage = damage;
		transform.GetChild (0).transform.GetChild (1).transform.GetChild (0).transform.GetChild(0).GetComponent<particle> ().damage = damageArea;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0) & canFire) {
			StartCoroutine(shoot());
		}
	}
}