using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayStats : MonoBehaviour {


	public Text shooting_speed;
	public Text damage;
	public Text range;
	public Text energy_cost;

	// Use this for initialization
	void Start () {

		Debug.Log ("avant");
			shooting_speed.text = GetComponent<dragAndDrop> ().itemToDrag.GetComponent<towerScript> ().fireRate.ToString();
			damage.text = GetComponent<dragAndDrop> ().itemToDrag.GetComponent<towerScript> ().damage.ToString();
			range.text = GetComponent<dragAndDrop> ().itemToDrag.GetComponent<towerScript> ().range.ToString();
			energy_cost.text = GetComponent<dragAndDrop> ().itemToDrag.GetComponent<towerScript> ().energy.ToString();
		Debug.Log ("apres");
	}
}
