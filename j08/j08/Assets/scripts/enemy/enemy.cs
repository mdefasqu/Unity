using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	private GameObject player;
	public int life = 3;
	public int aggroRange = 10;
	public bool isPoping = false;

	private Vector3 popZone;
	private NavMeshAgent agent;
	private Animator animator;
	private bool canAttack = true;
	private bool giveXp = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		popZone = transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	IEnumerator depop(){
		for (int i = 0; i < 100; i++) {
			if(i > 60){
				transform.Translate(new Vector3(0, -0.001f, 0));
			}
			yield return new WaitForSeconds(0.1f);
		}
		Destroy (gameObject);
	}

	IEnumerator dealDamage()
	{
		int finalDamage;
		canAttack = false;
		for(int i = 0; i < 1; i++){
			yield return new WaitForSeconds(1.3f);
		}
		if (GetComponent<stats> ().chanceToHit (player)) {
			finalDamage = GetComponent<stats> ().finalDamage (player);
			player.GetComponent<stats> ().takeDamage (finalDamage);
		} else {
			Debug.Log ("enemy miss");
		}
		canAttack = true;
	}

	void attack(){
		if (Vector3.Distance (transform.position, player.transform.position) < GetComponent<stats> ().meleeRange) {
			animator.SetBool("run", false);
			animator.SetBool("attack", true);
			if(canAttack){
				StartCoroutine(dealDamage());
			}
			transform.LookAt(player.transform.position);
		} else {
			agent.destination = player.transform.position;
			animator.SetBool("run", true);
			animator.SetBool("attack", false);
		}


	}

	bool reachDestination(){
		if (!agent.pathPending)
		{
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Update is called once per frame
	void Update () {
		if (GetComponent<stats> ().isDie == false && isPoping == false) {
			if (Vector3.Distance (transform.position, player.transform.position) < aggroRange) {
				attack ();
			} else {
				agent.destination = popZone;
			}
			if (reachDestination ()) {
				animator.SetBool ("run", false);
				animator.SetBool ("idle", true);
			}
		} else if (GetComponent<stats> ().isDie) {
			StartCoroutine (depop ());
			if(giveXp == false){
				player.GetComponent<stats>().xp += GetComponent<stats>().xp;
				giveXp = true;
			}
		}
	}
}
