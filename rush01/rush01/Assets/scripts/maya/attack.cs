using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

	Animator animator;

	private bool canAttack = true;
	public GameObject focusEnemy = null;
	public AudioSource attaque;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}


	IEnumerator dealDamage(GameObject target)
	{
		canAttack = false;
		animator.SetBool ("attack", true);
		attaque.Play ();
		for(int i = 0; i < 1; i++){
			yield return new WaitForSeconds(0.8f);
		}
		animator.SetBool ("attack", false);
		if (target != null && target.tag == "Enemy") {
			if(GetComponent<stats>().chanceToHit(target)){
				int finalDamage = GetComponent<stats>().finalDamage(target);
				target.GetComponent<stats>().takeDamage(finalDamage);
			} else {
				Debug.Log ("player miss");
			}
		}
		canAttack = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0) || Input.GetKey (KeyCode.Mouse0)) {

			Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;


			if (Physics.Raycast (cursorRay.origin, cursorRay.direction, out hit, 100)) {
				if (hit.collider.tag == "Enemy" && (Vector3.Distance (hit.collider.transform.position, transform.position) < GetComponent<stats> ().meleeRange)) {

					transform.LookAt(hit.collider.transform.position);
					if(canAttack){
						if(hit.collider.tag == "Enemy" && canAttack){
							focusEnemy = hit.collider.gameObject;
							StartCoroutine(dealDamage(focusEnemy));
						} else if (canAttack){
							StartCoroutine(dealDamage(focusEnemy));
						}
					}
				}
			}
			if(focusEnemy !=  null && canAttack) {
				StartCoroutine(dealDamage(focusEnemy));
			}
		} else {
			focusEnemy = null;
			animator.SetBool ("attack", false);
		}
	}
}
