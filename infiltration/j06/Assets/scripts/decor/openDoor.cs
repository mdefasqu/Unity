using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

	public GameObject door;
	private bool isOpen = false;
	 
	public void open ()
	{
		isOpen = true;
		Debug.Log ("porte ouverte");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isOpen)
			door.transform.Translate (new Vector3(0, 0.01f, 0));
	}
}
