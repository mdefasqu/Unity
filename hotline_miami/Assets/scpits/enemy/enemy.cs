using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public GameObject pathFind = null;
	public float speed;
	public AudioClip[] adie;
	
	[HideInInspector] public GameObject equipWeapon;

	private bool inAlert;
	private bool goSpawn;
	private bool endAlert;
	private bool patrol;
	private GameObject hero;
	private Vector3 spawnPos;
	private float spawnRot;
	private Transform spawnTransform;


	private int currentPathTarget;
	private int nb_path;


//	public bool inPathAltert;
//	private bool dont_enter;
//	public Transform exit_pos;
//
//	IEnumerator wait_door()
//	{
//		dont_enter = true;
//		yield return new WaitForSeconds (5);
//		dont_enter = false;
//	}
//	
//	IEnumerator find_door()
//	{
//		CircleCollider2D[] coll = GetComponents<CircleCollider2D> ();
//		coll [0].enabled = false;
//		coll [1].enabled = false;
//		
//		RaycastHit2D[] ray;
//		int e = 0;
//		//Physics2D.CircleCastAll(
//		ray = Physics2D.CircleCastAll (transform.position, 7, hero.transform.position - transform.position, 2);
//		coll [0].enabled = true;
//		coll [1].enabled = true;
//		for (int i = 0; i < ray.Length; ++i) {
//			if (ray [i].collider.gameObject.tag == "path") {
//				exit_pos = ray [i].collider.gameObject.transform;
//				inPathAltert = true;
//				StartCoroutine (wait_door ());
//				break;
//
//			}
//			yield return 0;
//		}
//	}
//
//	void OnCollisionStay2D(Collision2D collision)
//	{
//		if (collision.gameObject.tag == "decor" && !inPathAltert && !dont_enter) {
//			StartCoroutine(find_door());
//		}
//	}



	// Use this for initialization
	void Start () {

//		inPathAltert = false;
//		dont_enter = false;

		if (pathFind.transform.childCount > 1) {
			Debug.Log ("non");
			patrol = true;
		} else {
			patrol = false;
		}
		currentPathTarget = 0;
		nb_path = pathFind.transform.childCount;
		spawnTransform = transform;

		endAlert = false;
		inAlert = false;
		goSpawn = false;
		spawnPos = transform.position;
		spawnRot = transform.eulerAngles.z;
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
		hero = GameObject.FindGameObjectWithTag ("hero");
		equipWeapon = GetComponent<enemy_weapons> ().currentWeapon;
		gameObject.transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = equipWeapon.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
	}






	void goTo(int child){
		Vector3 toTargetVector = pathFind.transform.GetChild (child).transform.position - transform.position;
		float zRotation = Mathf.Atan2( toTargetVector.y, toTargetVector.x )*Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3 ( 0, 0, zRotation-90));
					
		float journeyLength = Vector3.Distance(transform.position, pathFind.transform.GetChild (child).transform.position);
		float distCovered = 0.08f;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(transform.position, pathFind.transform.GetChild (child).transform.position, fracJourney);
	}

	void goPatrol(){
		goTo (currentPathTarget);
		if (Vector3.Distance(transform.position, pathFind.transform.GetChild (currentPathTarget).transform.position) <= 0.5F)
			currentPathTarget++;
		if (currentPathTarget > pathFind.transform.childCount - 1)
			currentPathTarget = 0;
	}






	public void die()
	{
		AudioSource.PlayClipAtPoint (adie[Random.Range(0, adie.Length)], transform.position);
		Destroy (gameObject);
	}

	bool in_sight()
	{
		GetComponent<CircleCollider2D> ().enabled = false;
		RaycastHit2D ray = Physics2D.Raycast(transform.position, hero.transform.position - transform.position);
		//Debug.DrawRay (transform.position, hero.transform.position - transform.position);
		GetComponent<CircleCollider2D> ().enabled = true;
		if (ray.collider.gameObject.tag == "hero")
			return true;
		return false;
	}

	void goToSpawn(){
		Debug.Log ("gospawn");
		transform.position = spawnPos;
		transform.rotation = Quaternion.AngleAxis(spawnRot, new Vector3(0,0,10));
		goSpawn = false;
	}

	void follow()
	{

		//Regarde le hero
		Vector3 toTargetVector = hero.transform.position - transform.position;
		float zRotation = Mathf.Atan2( toTargetVector.y, toTargetVector.x )*Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3 ( 0, 0, zRotation-90));

		//Se deplace vers le hero
		GetComponent<Rigidbody2D>().AddForce((hero.transform.position - transform.position) * speed);

	}


	IEnumerator IEstopAlert(){
		for(int i = 0; i < 3; i++){
			yield return new WaitForSeconds(1);
		}
		if (inAlert == false) {
			stopAlert();
		}
	}


	void startAlert(){

		inAlert = true;
		endAlert = true;
		patrol = false;
		currentPathTarget = 0;
		gameObject.GetComponent<PolygonCollider2D> ().enabled = false;
		gameObject.AddComponent<CircleCollider2D> ();
		gameObject.GetComponent<CircleCollider2D>().radius = 13;
		gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
	}

	void stopAlert(){
		if (endAlert) {
			Destroy (gameObject.GetComponent<CircleCollider2D> ());
			gameObject.GetComponent<PolygonCollider2D> ().enabled = true;
			endAlert = false;
		}
		goSpawn = true;
	}

	void OnTriggerEnter2D(Collider2D collision){
	}

	void OnTriggerStay2D(Collider2D collision) {
		if (collision.gameObject.tag == "hero") {
			if (inAlert == false  && in_sight())
				startAlert ();
		} else if (collision.gameObject.name == "generic_bullet(Clone)") {
			if (inAlert == false)
				startAlert ();
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.tag == "hero") {
			//Invoke("stopAlert", 3);
			inAlert = false;
			StartCoroutine(IEstopAlert());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (inAlert && hero.activeInHierarchy) {
			follow ();
			GetComponent<enemy_weapons> ().shoot ();
		} else if (patrol){
			goPatrol();
		} else if (goSpawn){
			goToSpawn();
			patrol = true;
		} 

	}

//	void Update () {
//		if (inPathAltert) {
//			Vector3 toTargetVector = exit_pos.transform.position - transform.position;
//			float zRotation = Mathf.Atan2( toTargetVector.y, toTargetVector.x )*Mathf.Rad2Deg;
//			transform.rotation = Quaternion.Euler(new Vector3 ( 0, 0, zRotation-90));
//			
//			float journeyLength = Vector3.Distance(transform.position, exit_pos.position);
//			float distCovered = 0.1f;
//			float fracJourney = distCovered / journeyLength;
//			transform.position = Vector3.Lerp(transform.position, exit_pos.position, fracJourney);
//			if (journeyLength == 0)
//				inPathAltert = false;
//		}
//		else if (inAlert && hero.activeInHierarchy) {
//			follow ();
//			GetComponent<enemy_weapons> ().shoot ();
//		}
//		else if (goSpawn){
//			goToSpawn();
//		}
//	}

}
