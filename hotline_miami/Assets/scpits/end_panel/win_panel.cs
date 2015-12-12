using UnityEngine;
using System.Collections;

public class win_panel : MonoBehaviour {


	public void continue_lvl()
	{
		if (Application.levelCount > Application.loadedLevel + 1) {
			Application.LoadLevel (Application.loadedLevel + 1);
		} else {
			Application.LoadLevel(0);
		}
	}
	
	public void back()
	{
		Application.LoadLevel(0);
	}
}
