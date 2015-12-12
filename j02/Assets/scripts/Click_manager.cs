using UnityEngine;
using System.Collections;

public class Click_manager : MonoBehaviour {

	private Vector3 wantedPos;

	// Use this for initialization

	public Vector3 get_mouse_pos()
	{
			Vector3 mousePos = Input.mousePosition;
			wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 1.0F));
			//Debug.Log (wantedPos);
			return wantedPos;
	}

	void Start () {
	}
	void Update () {
	}
}
