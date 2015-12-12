using UnityEngine;
using System.Collections;

public class weapon_spawner : MonoBehaviour {

	public GameObject[] weapons;
	public GameObject bullet;
	public AudioSource aPickUp;
	public AudioSource aDrop;
	[HideInInspector] public GameObject currentWeapon;
	[HideInInspector] public GameObject hero;
	[HideInInspector] public float ammo;

	private bool isHold;
	private int bullet_speed;
	private float cadence;
	private int rafale;
	private bool canFire;

	// Use this for initialization
	void Start () {
		canFire = true;
		hero = GameObject.FindGameObjectWithTag ("hero");
		currentWeapon = weapons[Random.Range (0, weapons.Length)];
		gameObject.GetComponent<SpriteRenderer> ().sprite = currentWeapon.GetComponent<SpriteRenderer> ().sprite;
		bullet_speed = currentWeapon.GetComponent<weapon_stat> ().bullet_speed;
		rafale = currentWeapon.GetComponent<weapon_stat> ().rafale;
		if (currentWeapon.GetComponent<weapon_stat> ().type == "melee") {
			ammo = Mathf.Infinity;
		} else {
			ammo = currentWeapon.GetComponent<weapon_stat> ().ammo;
		}
		cadence = currentWeapon.GetComponent<weapon_stat> ().cadence;
	}

	public IEnumerator fire(int rafale, float cadence){
		GameObject shot_bullet;
		canFire = false;
		hero.GetComponent<AudioSource> ().clip = currentWeapon.GetComponent<weapon_stat> ().fire_sound;
		hero.GetComponent<AudioSource> ().Play();
		for (int i = 0; i < rafale; i++) {
			shot_bullet = valid_bullet ();
			shot_bullet.GetComponent<Rigidbody2D> ().velocity = hero.transform.right * bullet_speed;
			ammo--;
			yield return new WaitForSeconds(0.01f);
		}
		yield return new WaitForSeconds (cadence);
		canFire = true;
	}

	public GameObject valid_bullet()
	{

		GameObject Vbullet = Instantiate (bullet, hero.transform.GetChild(3).transform.position, Quaternion.Euler(new Vector3(0, 0, hero.transform.eulerAngles.z))) as GameObject;
		Vbullet.GetComponent<SpriteRenderer> ().sprite = currentWeapon.transform.GetChild (0).GetComponent<SpriteRenderer>().sprite;
		Vbullet.GetComponent<bullet> ().owner = "hero";
		Destroy(Vbullet.GetComponent<PolygonCollider2D>());
		Vbullet.AddComponent<PolygonCollider2D>();

		return Vbullet;
	}

	void drop()
	{
		if (isHold && Input.GetKeyDown (KeyCode.Mouse1)) {
			isHold = false;
			aDrop.Play();
			transform.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
			slide ();
		}
	}

	void slide()
	{
		GetComponent<Rigidbody2D> ().velocity = hero.transform.right * 5;
	}	

	void OnTriggerStay2D(Collider2D collision) {
		if (collision.gameObject.tag == "hero" && Input.GetKey(KeyCode.E) && hero.GetComponent<hero>().equipWeapon == false) {
			aPickUp.Play();
			isHold = true;
		}
	}

	public void shoot()
	{
		if (canFire && ammo > 0)
			StartCoroutine (fire (rafale, cadence));
	}

	// Update is called once per frame
	void Update () {
		if (isHold) {
			transform.position = hero.transform.position;
			transform.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
		}
		drop ();
	}
}
