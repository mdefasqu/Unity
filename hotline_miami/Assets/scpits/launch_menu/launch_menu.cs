using UnityEngine;
using System.Collections;

public class launch_menu : MonoBehaviour {

	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;

	public void launch_game()
	{
		int level = PlayerPrefs.GetInt("last_level");
		if (level + 1  <= Application.levelCount && level > 0) {
			Application.LoadLevel (level);
		} else {
			Application.LoadLevel(1);
		}

	}

	public void quit_game()
	{
		Application.Quit ();
	}

	void Start(){
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
	}
}
