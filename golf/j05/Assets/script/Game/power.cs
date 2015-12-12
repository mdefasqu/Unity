using UnityEngine;
using System.Collections;

public class power : MonoBehaviour {

	public GameObject jauge;


	public bool shooting = false;
	public float power_value = 0;

	private bool charge = true;



	public float choose_power()
	{
		if (jauge.transform.localScale.y <= 1 && charge)
			jauge.transform.localScale += new Vector3 (0, 0.05F, 0);
		else {
			jauge.transform.localScale += new Vector3 (0, -0.05F, 0);
			charge = false;
		}
		if (jauge.transform.localScale.y <= 0)
			charge = true;
		return jauge.transform.localScale.y;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (shooting == true) {
			power_value = choose_power();
		}
	}
}
