using UnityEngine;
using System.Collections;

public class follow_player : MonoBehaviour {

	public GameObject player;

	public int posX = -8;
	public int posY = 8;
	public int posZ = -6;
	private bool IsChange= false;
	public AudioClip next;
	// Use this for initialization
	void Start () {
		Debug.Log ("camera");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + new Vector3(posX, posY, posZ);
		if (Application.loadedLevel == 1 && IsChange == false) {
			posX = 0;
			posY = 6;
			posZ = -6;
			transform.rotation = Quaternion.identity;
			transform.Rotate(32,0,0);
			IsChange = true;
			GetComponent<AudioSource>().clip = next;
			GetComponent<AudioSource>().Play();
		}
	}
}
