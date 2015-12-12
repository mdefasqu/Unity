using UnityEngine;
using System.Collections;

public class moves : MonoBehaviour {

	private NavMeshAgent agent;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}


	IEnumerator gameOver(){
		GetComponent<NavMeshAgent> ().enabled = false;
		for (int i = 0; i < 100; i++) {
			yield return new WaitForSeconds(0.2f);
		}
		Application.LoadLevel(Application.loadedLevel);
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
		if (GetComponent<stats> ().isDie) {
			StartCoroutine (gameOver ());
		} else {

			if ((Input.GetKeyDown (KeyCode.Mouse0) || Input.GetKey (KeyCode.Mouse0)) && GetComponent<attack>().focusEnemy == null) {

				Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (cursorRay.origin, cursorRay.direction, out hit, 100)) {
					if (hit.collider.tag != "Enemy" || (Vector3.Distance (hit.collider.transform.position, transform.position) > GetComponent<stats> ().meleeRange)) {
						if (hit.collider.tag == "Enemy") {
							agent.stoppingDistance = 2f;
							agent.destination = hit.collider.transform.position;
						} else {
							agent.stoppingDistance = 0f;
							agent.destination = hit.point;
						}
					} 
				}
			}

			if (reachDestination ()) {
				animator.SetBool ("run", false);
			} else {
				animator.SetBool ("run", true);
			}

		}
	}
}
