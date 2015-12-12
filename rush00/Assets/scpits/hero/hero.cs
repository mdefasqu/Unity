using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour {

	public int speed;
	public float boost;
	public AudioClip[] adie;
	public AudioSource aLoose;
	public AudioSource aWin;


	[HideInInspector]public bool isDie;
	[HideInInspector]public bool isWin;
	private GameObject die_panel;
	private GameObject win_panel;
	private float use_speed;
	private float mouseX;
	private float mouseY;
	[HideInInspector] public GameObject equipWeapon;
	// Use this for initialization
	void Start () {
		isDie = false;
		isWin = false;
		Physics2D.raycastsHitTriggers = false;
		equipWeapon = null;
		die_panel = GameObject.Find("die_panel");
		win_panel = GameObject.Find("win_panel");
		die_panel.SetActive (false);
		win_panel.SetActive (false);
	}

	public void display_win(bool display){
		isWin = true;
		if (display) {
			aWin.Play();
			win_panel.SetActive(display);
		}
	}

	void display_die(bool display){
		if (display) {
			AudioSource.PlayClipAtPoint (aLoose.clip, transform.position);
			die_panel.SetActive(display);
			gameObject.SetActive(false);
		}
	}

	void change_weapon(GameObject weapon){
		equipWeapon = weapon;
	}

	void displayWeapon ()
	{
		if (equipWeapon == null) {
			gameObject.transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = null;
		} else {
			gameObject.transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = equipWeapon.GetComponent<weapon_spawner>().currentWeapon.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
		}
	}

	void dropWeapon ()
	{
		if (Input.GetKeyDown (KeyCode.Mouse1) && equipWeapon != null) {
			equipWeapon = null;
		}
	}

	public void die(){
		AudioSource.PlayClipAtPoint (adie[Random.Range(0, adie.Length)], transform.position);
		display_die (true);
		isDie = true;
	}

	void shoot()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0) && equipWeapon != null) {
			equipWeapon.GetComponent<weapon_spawner>().shoot();
		}
	}

	void move(){
		//deplacements :
		if (Input.GetKey (KeyCode.LeftShift)) {
			use_speed = speed * boost;
		} else {
			use_speed = speed;
		}
		if (Input.GetKey (KeyCode.W)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, use_speed));
		} else if (Input.GetKey (KeyCode.S)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -use_speed));
		} else if (Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(-use_speed, 0));
		} else if (Input.GetKey(KeyCode.D)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(use_speed, 0));
		}
		
		//orientation :
		Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void OnTriggerStay2D(Collider2D collision) {
		if (collision.gameObject.tag == "weapon" && equipWeapon == null && Input.GetKey(KeyCode.E)) {
			change_weapon(collision.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		move ();
		displayWeapon ();
		dropWeapon ();
		shoot ();
	}
}
