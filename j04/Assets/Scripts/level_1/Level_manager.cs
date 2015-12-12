using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level_manager : MonoBehaviour {

	public GameObject hud;
	public Text score_screen;
	public GameObject sonic;
	public GameObject ring_rb;
	public static Level_manager lm;
	public AudioSource aLevel;
	public GameObject pm;


	[HideInInspector]public int current_score;
	[HideInInspector]public bool finish;
	private float timer;
	private int final_score;
	private int current_level;


	IEnumerator finish_routine()
	{
		final_score = (sonic.GetComponent<Sonic> ().rings * 500) + (current_score * 100) + (20000 - Mathf.RoundToInt (timer));
		for(int i = 0; i < 3; i++){
			if (i == 1)
			{
				score_screen.text = "score : "+ final_score.ToString();

			}
			else if(i == 2)
			{
				if(final_score > PlayerPrefs.GetInt("score_" + (current_level - 1))){
					pm.GetComponent<player_pref_manager>().UpdateScore(final_score, (current_level - 1));
				}
				pm.GetComponent<player_pref_manager>().UpdateRings(sonic.GetComponent<Sonic>().rings);
				pm.GetComponent<player_pref_manager>().UnlockLevel(current_level);
				sonic.GetComponent<Sonic>().speedFactor = 0;
				Application.LoadLevel(1);
			}
			sonic.GetComponent<Sonic>().speedFactor = 5;
			yield return new WaitForSeconds(6);
		}
	}

	void Awake(){
		if (lm == null) {
			lm = this;
		}
	}

	// Use this for initialization
	void Start () {
		//music.Play ();
		current_level = Application.loadedLevel;
		score_screen.text = "";
		current_score = 0;
		hud.transform.GetChild(0).GetComponent<Text>().text = "score : " + current_score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (finish) {
			aLevel.Stop();
			StartCoroutine (finish_routine ());
		} else {
			timer += Time.deltaTime;
		}
		hud.transform.GetChild(0).GetComponent<Text>().text = "score : " + current_score.ToString();
		hud.transform.GetChild(1).GetComponent<Text>().text = "time : " + (Mathf.RoundToInt (timer) / 60).ToString() + ":" + (Mathf.RoundToInt (timer) % 60).ToString();
		hud.transform.GetChild(2).GetComponent<Text>().text = sonic.GetComponent<Sonic>().rings.ToString();

	}
}