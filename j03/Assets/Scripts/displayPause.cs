using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayPause : MonoBehaviour {

	public GameObject panel;
	public GameObject panel_exit;
	public GameObject panel_score;
	public Text next;
	public Text score;
	public Text rank;

	private int current_level;
	private int status;
	// Use this for initialization
	void Start () {
		current_level = Application.loadedLevel;
		panel.SetActive (false);
		panel_score.SetActive(false);
		status = 0;
	}

	public void pause_resume()
	{
		panel.SetActive(false);
		gameManager.gm.pause (false);
		Debug.Log(Time.timeScale);
	}

	public void exit_game()
	{
		panel_exit.SetActive (true);
	}

	public void confirm_yes()
	{
		Application.LoadLevel ("ex00");
	}

	public void next_action()
	{
		if (status == 1)
			Application.LoadLevel (current_level);
		else if (status == 2)
			Application.LoadLevel (current_level+1);
	}

	public void confirm_no()
	{
		panel_exit.SetActive (false);
	}
	// Update is called once per frame
	private string get_rank(int pv, int energy)
	{
		string rank;
		int score = pv * energy;

		if (score <= 5000) {
			return ("Mathias");
		} else if (score > 5000 && score <= 12000) {
			return "rank 1";
		}else if (score > 1200 && score <= 19000) {
			return "rank 2";
		}else if (score > 19000 && score <= 35000) {
			return "rank 3";
		}else if (score > 35000 && score <= 50000) {
			return "rank 4";
		} else {
			return "AMAZING";
		}

		return rank;
	}


	void Update () {

		score.text = "Score : "+gameManager.gm.score.ToString();
		rank.text = "Rank : " + get_rank (gameManager.gm.playerHp, gameManager.gm.playerEnergy);

		if (Input.GetKeyDown (KeyCode.Escape) && panel.activeInHierarchy) {
			gameManager.gm.pause (false);
			panel.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			gameManager.gm.pause (true);
			panel.SetActive (true);
			panel_exit.SetActive (false);
		}

		if (gameManager.gm.playerHp <= 0) {
			panel_score.SetActive(true);
			next.text = "Retry";
			status = 1;

		}
		if (gameManager.gm.win) {
			panel_score.SetActive(true);
			next.text = "Next level";
			status = 2;
		}
	}
}