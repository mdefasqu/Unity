using UnityEngine;
using System.Collections;

public class stats : MonoBehaviour {

	[HideInInspector] public int life = 1;
	public float meleeRange = 3F;
	public int Strengh = 15;
	public int Agility = 15;
	public int Constitution = 20;
	public int Armor = 0;
	public string entityName = "Maya";
	public int regenRate = 1;

	private bool regenTime = true;

	[HideInInspector] public int hp;
	[HideInInspector] public int minDmg;
	[HideInInspector] public int maxDmg;
	public int level = 1;
	[HideInInspector] public int xp;
	[HideInInspector] public int money;
	[HideInInspector] public int skills;
	[HideInInspector] public int spellsPt;
	[HideInInspector] public bool isDie = false;
	[HideInInspector] public int xpToUp;
	// Use this for initialization

	IEnumerator regen(int regenRate){
		regenTime = false;
		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(1);
		}
		life += regenRate;
		regenTime = true;
	}

	private int baseDamage(){
		return Random.Range (minDmg, maxDmg);
	}

	public int finalDamage(GameObject target){
		return baseDamage () * (1 - target.GetComponent<stats> ().Armor / 200);
	}

	public bool chanceToHit(GameObject target){
		if (Random.Range (0, 100) > (75 + Agility - target.GetComponent<stats> ().Agility))
			return false;
		else
			return true;
	}

	public void takeDamage(int damage)
	{
		life -= damage - Armor;
	}

	private void checkZero(){
		if (life < 0) {
			life = 0;
		}
		if (life > hp) {
			life = hp;
		}
	}

	void Start () {
		xpToUp = 2 * (level * 100);
		hp = 5 * Constitution;
		life = hp;
		minDmg = Strengh / 2;
		maxDmg = minDmg + 4;
	}
	
	// Update is called once per frame
	void Update () {

		checkZero ();
		hp = 5 * Constitution;
		minDmg = Strengh / 2;
		maxDmg = minDmg + 4;
		if (life <= 0 && isDie == false) {
			GetComponent<Animator>().SetTrigger("die");
			isDie = true;
		}
		if (xp >= xpToUp && transform.tag == "Player") {
			GetComponent<levelUp>().PlayerLevelUp();
		}
		if (regenTime) {
			StartCoroutine (regen (regenRate));
		}
	}
}
