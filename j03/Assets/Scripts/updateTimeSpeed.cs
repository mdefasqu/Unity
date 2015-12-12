using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updateTimeSpeed : MonoBehaviour {

	private string	text;
	static int		y = 0;
	
	void Update() {
		float state = Time.timeScale;
		text = null;
		if (y == 0) {
			Time.timeScale = 0;
			state = 0;
			y = 1;
		}
		if (y == 1 && state == 0) {
			text = "PRESS PLAY TO START";
		} else if (state == 0) {
			text = "PAUSED";
			y = 2;
		} else {
			text = "SPEED: " + state.ToString () + "X";
			y = 2;
		}
		if (text != null)
			GetComponent<Text> ().text = text;
	}
}
