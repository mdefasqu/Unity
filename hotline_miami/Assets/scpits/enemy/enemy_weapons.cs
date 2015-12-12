using UnityEngine;
using System.Collections;

public class enemy_weapons : MonoBehaviour {

	public GameObject[] weapons;
	public GameObject bullet;
	[HideInInspector] public GameObject currentWeapon;


	private bool isHold;
	private int bullet_speed;
	private float cadence;
	private int rafale;
	private bool canFire;

	// Use this for initialization

	void Start () {
		canFire = true;
		currentWeapon = weapons[Random.Range (0, weapons.Length)];
		bullet_speed = currentWeapon.GetComponent<weapon_stat> ().bullet_speed;
		rafale = currentWeapon.GetComponent<weapon_stat> ().rafale;
		cadence = currentWeapon.GetComponent<weapon_stat> ().cadence;
	}

	public IEnumerator fire(int rafale, float cadence){
		GameObject shot_bullet;
		canFire = false;
		GetComponent<AudioSource> ().clip = currentWeapon.GetComponent<weapon_stat> ().fire_sound;
		gameObject.GetComponent<AudioSource> ().Play ();
		for (int i = 0; i < rafale; i++) {
			shot_bullet = valid_bullet ();
			shot_bullet.GetComponent<Rigidbody2D> ().velocity = transform.up * bullet_speed;

			yield return new WaitForSeconds(0.01f);
		}
		yield return new WaitForSeconds (cadence);
		canFire = true;
	}
	
	public GameObject valid_bullet()
	{
		GameObject Vbullet = Instantiate (bullet, gameObject.transform.GetChild(3).transform.position, Quaternion.Euler(new Vector3(0, 0, gameObject.transform.eulerAngles.z + 90))) as GameObject;
		Vbullet.GetComponent<SpriteRenderer> ().sprite = currentWeapon.transform.GetChild (0).GetComponent<SpriteRenderer>().sprite;
		Destroy(Vbullet.GetComponent<PolygonCollider2D>());
		Vbullet.AddComponent<PolygonCollider2D>();
		
		return Vbullet;
	}
	
	public void shoot()
	{
		if (canFire)
			StartCoroutine (fire (rafale, cadence));
	}


	
	// Update is called once per frame
	void Update () {
	}
}
