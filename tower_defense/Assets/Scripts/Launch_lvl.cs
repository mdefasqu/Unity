using UnityEngine;
using System.Collections;

public class Launch_lvl : MonoBehaviour {

	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;
	
	void Start() {
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
	}

	public void play_lvl()
	{
		Application.LoadLevel ("ex01");
	}
	public void exit_lvl()
	{
		Application.Quit ();
	}
}


