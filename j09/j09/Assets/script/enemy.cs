using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	[HideInInspector] public int aggroRange = 12;
	[HideInInspector] public int attackRange = 2;
	[HideInInspector] public int runSpeed = 10;
	[HideInInspector] public int attackDamage;
	[HideInInspector] public GameObject dest = null;
	[HideInInspector] public GameObject player = null;

	[HideInInspector] public int hp = 1;
	// Use this for initialization
	private Animator anim;
	private bool canAttack = true;

	void rush(){
		anim.SetBool ("run", true);
		GetComponent<NavMeshAgent> ().speed = runSpeed;
		if(player != null)
			GetComponent<NavMeshAgent> ().destination = player.transform.position;
	}

	IEnumerator dealDamage(){
		canAttack = false;
		yield return new WaitForSeconds (1);
		if(player != null)
			player.GetComponent<player> ().hp -= attackDamage;
		yield return new WaitForSeconds (1);
		canAttack = true;
	}

	void attack(){
		if(player != null)
			GetComponent<NavMeshAgent> ().destination = player.transform.position;
		anim.SetBool ("run", false);
		anim.SetBool ("attack", true);
		StartCoroutine (dealDamage());
	}

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float dist;

		if (player != null) {
			dist = Vector3.Distance (transform.position, player.transform.position);
		} else {
			dist = 100;
		}

		GetComponent<NavMeshAgent> ().destination = dest.transform.position;
		if (hp <= 0) {
			GetComponent<NavMeshAgent>().Stop();
			Destroy(gameObject);
		}
		if (dist < aggroRange && dist > attackRange) {
			rush();
		}
		if(dist < attackRange){
			attack();
		}
	}
}
