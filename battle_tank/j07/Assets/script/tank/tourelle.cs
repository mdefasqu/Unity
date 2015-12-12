using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tourelle : MonoBehaviour {

	public GameObject cursor;
	public GameObject chenilles;
	public ParticleSystem missile;
	public ParticleSystem rifle;
	public AudioSource aRifle;
	public AudioSource aMissile;
	public GameObject nbAmmo;
	public GameObject nbLife;
	public int missileCount = 8;
	public int life = 100;

	private bool canShootRifle = true;
	private bool canShootMissile = true;

	IEnumerator changeCursor(){
		cursor.GetComponent<Image>().color = Color.red;
		for (int i = 0; i < 1; i++) {
			yield return new WaitForSeconds(0.2f);
		}
		cursor.GetComponent<Image> ().color = Color.white;

	}

	void explodeRifle(RaycastHit hit){
		ParticleSystem impact = Instantiate (rifle, hit.point, Quaternion.identity) as ParticleSystem;
		impact.Play ();
	}

	void explodeMissile(RaycastHit hit){
		transform.GetChild (0).transform.GetChild (1).GetComponent<ParticleSystem> ().Play ();
		ParticleSystem impact = Instantiate (missile, hit.point, Quaternion.identity) as ParticleSystem;
		//impact.Play ();
	}

	IEnumerator shoot_rifle(){
		RaycastHit hit;

		canShootRifle = false;
		aRifle.Play ();
		hit = shoot();
		if (hit.collider.tag == "tank") {
			hit.collider.GetComponent<life> ().nbLife -= 5;
			StartCoroutine(changeCursor());
		}
		explodeRifle(hit);
		for(int i = 0; i < 1; i++){
			yield return new WaitForSeconds(0.2f);
		}
		canShootRifle = true;
	}

	IEnumerator shoot_missile(){
		RaycastHit hit;

		missileCount--;
		nbAmmo.GetComponent<TextMesh> ().text = "x"+missileCount;
		canShootMissile = false;
		aMissile.Play ();
		hit = shoot();
		if (hit.collider.tag == "tank")
			hit.collider.GetComponent<life> ().nbLife -= 20;
		explodeMissile(hit);
		for(int i = 0; i < 1; i++){
			yield return new WaitForSeconds(1.5f);
		}
		canShootMissile = true;
	}

	RaycastHit shoot(){
		Vector3 fwd = transform.GetChild(0).transform.TransformDirection (Vector3.forward);
		Vector3 pos = transform.GetChild(0).transform.position;
		RaycastHit rayHit;
		if (Physics.Raycast (pos, fwd, out rayHit, 256))
			Debug.DrawLine (pos, rayHit.point, Color.red);
		return rayHit;
	}


	void Update ()
	{
		nbLife.GetComponent<TextMesh> ().text = transform.GetChild (0).GetComponent<life> ().nbLife.ToString();
		if (Input.GetKeyDown (KeyCode.Mouse0) && canShootRifle) {
			StartCoroutine(shoot_rifle());
		}
		if (Input.GetKeyDown (KeyCode.Mouse1) && canShootMissile && missileCount > 0) {
			StartCoroutine(shoot_missile());
		}
		transform.position = chenilles.transform.position;
		shoot ();

	}
}
