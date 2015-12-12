using UnityEngine;
using System.Collections;

public class die_panel : MonoBehaviour {

	public void restart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void back()
	{
		Application.LoadLevel (0);
	}
}
