using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataSheetManager : MonoBehaviour {


	public Text player_death;
	public Text player_rings;
	public Text level_name;
	public Text best_score;
	public Image selector;

	private int selected_level;
	private GameObject[] levels;

	// Use this for initialization
	void Start () {

		selected_level = 1;
		if (PlayerPrefs.GetInt ("player_death") > 0) {
			player_death.text = PlayerPrefs.GetInt ("player_death").ToString();
		} else {
			player_death.text = "0";
		}
		if(PlayerPrefs.GetInt ("player_rings") > 0){
			player_rings.text = PlayerPrefs.GetInt("player_rings").ToString();
		}else {
			player_rings.text = "0";
		}

		PlayerPrefs.SetInt ("level_1", 1);
		levels = GameObject.FindGameObjectsWithTag("level");
		foreach (GameObject level in levels) {
			Debug.Log (PlayerPrefs.GetString(level.name));
			if(PlayerPrefs.GetInt(level.name) != 1)
				level.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color (1F, 1F ,1F, 0.5F);
			else {
				level.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color (1F, 1F ,1F, 0F);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			selected_level += 1;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)){
			selected_level -= 1;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)){
			selected_level -= 4;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)){
			selected_level += 4;
		}
		if (selected_level > 12)
			selected_level = 12;
		else if (selected_level < 1)
			selected_level = 1;

		foreach (GameObject level in levels) {
			if(level.name == "level_"+ selected_level.ToString())
			{
				selector.transform.position = level.transform.position;
				level_name.text = level.transform.GetChild(1).gameObject.GetComponent<Text>().text;
				best_score.text = PlayerPrefs.GetInt("score_"+ selected_level).ToString();
			}
		}

		if (Input.GetKeyDown (KeyCode.Return) && PlayerPrefs.GetInt("level_"+selected_level) == 1) {
			if(Application.levelCount > 1 + selected_level){
				Application.LoadLevel(1+ selected_level);
			}
		}
	}
}
