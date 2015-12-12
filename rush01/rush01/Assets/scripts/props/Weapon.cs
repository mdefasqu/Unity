using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Weapon : MonoBehaviour {

	public int Constitution;
	public int Strengh;
	public int Agility;
	public int Armor;
	public int regenRate;
	public int DommageMin;
	public int DommageMax;
	public int atk_speed;
	public int item_level;
	public int quality;
	public bool build = false;
	public GameObject icon;
	// Use this for initialization
	void Start () {
	}

	void make_stats () {
		int y = 0;
		quality = Random.Range (1, 200);
		if (quality < 150)
			quality = 1;
		else if (quality < 185)
			quality = 2;
		else if (quality < 199)
			quality = 4;
		else if (quality == 199)
			quality = 8;
		item_level = item_level + (quality * 5);
		for (int i = 0; i < item_level; i++) {
			y = Random.Range(1, 9);
			if (y == 1)
				Constitution++;
			else if (y == 2)
				Strengh++;
			else if (y == 3)
				Agility++;
			else if (y == 4)
				Armor++;
			else if (y == 5)
				regenRate++;
			else if (y == 6)
				DommageMin++;
			else if (y == 7)
				DommageMax++;
			else if (y == 8)
				atk_speed++;
		}
	}

	// Update is called once per frame
	void Update () {
		if (build == false) {
			make_stats ();
			build = true;
		}
	}
}
