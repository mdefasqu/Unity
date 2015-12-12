using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class event_manager : MonoBehaviour {

	public GameObject soldier_orig;
	public GameObject orc_orig;
	public GameObject click_manager;

	private List<GameObject>  characters = new List<GameObject> ();
	private List<GameObject>  actives_characters = new List<GameObject> ();

	private List<GameObject>  orc = new List<GameObject> ();
	private List<GameObject>  actives_orc = new List<GameObject> ();

	void create_human()
	{
		characters.Add (Instantiate (soldier_orig, new Vector3 (-3.25F, 2.58F, 0), Quaternion.identity) as GameObject);
	}

	void create_orc()
	{
		characters.Add (Instantiate (orc_orig, new Vector3 (5.26F, 0.0F, 0), Quaternion.identity) as GameObject);
	}

	void Start () {
		InvokeRepeating("create_human", 0, 10F);
		InvokeRepeating("create_orc", 0, 10F);
	}

	void Update () {
		Vector3 mouse_pos;

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit && Input.GetKey (KeyCode.LeftControl)) {
				actives_characters.Add (hit.collider.gameObject);
				characters.Add (hit.collider.gameObject);
				Debug.Log ("grp");
			} else if (hit) {
				actives_characters.Clear ();
				actives_characters.Add (hit.collider.gameObject);
				Debug.Log ("seul");
			} else {
				mouse_pos = click_manager.GetComponent<Click_manager> ().get_mouse_pos ();
				foreach (GameObject soldier in actives_characters) {
					soldier.GetComponent<character> ().move_to (mouse_pos);
				}
			}

		} else if (Input.GetMouseButtonDown (1)) {
			actives_characters.Clear();
		}
	}
}