using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_pref_manager : MonoBehaviour {

	public void UpdateScore(int score, int level){
		Debug.Log ("set = "+score+"  lve = "+level);
		PlayerPrefs.SetInt("score_"+level, score);
		PlayerPrefs.Save();
	}

	public void UnlockLevel(int level){
		PlayerPrefs.SetInt ("level_"+level, 1);
		PlayerPrefs.Save();
	}

	public void UpdateDeath(){
		PlayerPrefs.SetInt("player_death", PlayerPrefs.GetInt("player_death")+1);
		PlayerPrefs.Save();
	}

	public void UpdateRings(int rings){
		Debug.Log (rings);
		rings = rings + PlayerPrefs.GetInt ("player_rings");
		Debug.Log ("rings = " + rings);
		PlayerPrefs.SetInt ("player_rings", rings);
		PlayerPrefs.Save();
	}
}
