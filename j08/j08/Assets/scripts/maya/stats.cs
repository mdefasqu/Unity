using UnityEngine;
using System.Collections;

public class stats : MonoBehaviour {

	[HideInInspector] public int life = 1;
	public float meleeRange = 3F;
	public int Strengh = 15;
	public int Agility = 15;
	public int Constitution = 20;
	public int Armor = 15;
	public string entityName = "none";
	public int regenRate = 1;

	private bool regenTime = true;
	[HideInInspector] public int hp;
	[HideInInspector] private int minDmg;
	[HideInInspector] private int maxDmg;

	[HideInInspector] public int level = 1;
	public int xp;
	private int money;
	private int skills;

	[HideInInspector] public bool isDie = false;

	[HideInInspector] public int xpToUp;
	// Use this for initialization

	IEnumerator regen(int regenRate){
		regenTime = false;
		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds(1);
		}
		life += regenRate;
		if (life > hp) {
			life = hp;
		}
		regenTime = true;
		Debug.Log ("regen");
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

	public void levelUp(){
		int pourcent = 15;

		level += 1;
		xp = xp - xpToUp;
		xpToUp = xpToUp + ((xpToUp * pourcent) / 100);
		life = hp;
		skills += 5;
		transform.GetComponent<ParticleSystem> ().Play ();
	}

	public void takeDamage(int damage)
	{
		life -= damage;
	}

	private void checkZero(){
		if (life < 0) {
			life = 0;
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
		xpToUp = 2 * (level * 100);
		hp = 5 * Constitution;
		minDmg = Strengh / 2;
		maxDmg = minDmg + 4;
		if (life <= 0 && isDie == false) {
			GetComponent<Animator>().SetTrigger("die");
			isDie = true;
		}
		if (xp >= xpToUp && transform.tag == "Player") {
			levelUp();
		}
		if (regenTime) {
			StartCoroutine (regen (regenRate));
		}
	}
}
