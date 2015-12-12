using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void reset_button()
	{
		PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel(1);
		}
	}
}
