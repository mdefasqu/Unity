using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject nbLife;
	public ParticleSystem[] typeImpact;
	public AudioSource[] soundImpact;
	public int life = 100;
	private GameObject[] targets;
	[HideInInspector] public GameObject validTarget = null;

	private bool canFire = true;
	// Use this for initialization
	void Start () {
		targets = GameObject.FindGameObjectsWithTag ("tank");

		foreach (GameObject tank in targets) {
			if(Vector3.Distance(transform.position, tank.transform.position) == 0){
			} else if (!validTarget) {
				validTarget = tank;
			} else if (Vector3.Distance(transform.position, tank.transform.position) < Vector3.Distance(transform.position, validTarget.transform.position)){
				validTarget = tank;
			}
		}
	}

	RaycastHit shoot(){
		Vector3 fwd = transform.GetChild(0).transform.TransformDirection (Vector3.forward);
		Vector3 pos = transform.GetChild(0).transform.position;
		RaycastHit rayHit;
		if (Physics.Raycast (pos, fwd, out rayHit, 256)) {
		}
		return rayHit;
	}

	IEnumerator agentFire(float time, GameObject target){
		canFire = false;
		int type = 0;
		int touch = Random.Range (0, 8);
		ParticleSystem impact;
		RaycastHit shot;

		shot = shoot ();

		transform.GetChild (0).transform.GetChild (1).GetComponent<ParticleSystem> ().Play ();
		Debug.Log ("feu");
		soundImpact [type].Play ();
		if (touch > 2) {
			if(shot.transform.tag == "tank"){
				shot.collider.GetComponent<life>().nbLife -= 10;
			}
			impact = Instantiate (typeImpact[type], shot.point, Quaternion.identity) as ParticleSystem;
		} else {
			impact = Instantiate (typeImpact[type], shot.point + new Vector3(Random.Range(5,10), 0, Random.Range(5,10)), Quaternion.identity) as ParticleSystem;
		}
		for (int i = 0; i < 1; i++) {
			yield return new WaitForSeconds(time);
		}
		canFire = true;
	}

	
	// Update is called once per frame
	void Update () {

		nbLife.GetComponent<TextMesh> ().text = GetComponent<life> ().nbLife.ToString ();
		foreach (GameObject tank in targets) {
			if(Vector3.Distance(transform.position, tank.transform.position) == 0){
			} else if (!validTarget) {
				validTarget = tank;
			} else if (Vector3.Distance(transform.position, tank.transform.position) < Vector3.Distance(transform.position, validTarget.transform.position)){
				validTarget = tank;
			}
		}
		GetComponent<NavMeshAgent> ().destination = validTarget.transform.position;
		if(validTarget != null && canFire && GetComponent<life>().nbLife > 0)
			StartCoroutine(agentFire(Random.Range(1,4), validTarget));
	}
}
