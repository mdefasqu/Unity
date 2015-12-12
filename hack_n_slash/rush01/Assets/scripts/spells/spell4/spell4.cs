using UnityEngine;
using System.Collections;

public class spell4 : MonoBehaviour {

	public int spellLVL = 1;
	public int damage = 0;
	public int range = 8;
	public int cd = 0;
	public GameObject effect;
	public AudioSource aoe;


	public string getToolTip(){
		return ("Niveau du sort : "+spellLVL+
		        "\nDegats du sort : "+damage * spellLVL+
		        "\nUne explosion de feu infligeant "+damage * spellLVL+" a tous les enemis dans les "+range+"m autour du joueur");
	}

	public void upgradeSpell(){
		spellLVL += 1;
	}

	IEnumerator autoDestroy(GameObject spell){
		yield return new WaitForSeconds (10);
		Destroy (spell);
	}
	
	public int Cast(GameObject target, GameObject caster){
		Debug.Log ("spell4");
		GameObject spell = Instantiate (effect, caster.transform.position, Quaternion.identity) as GameObject;
		spell.GetComponent<ParticleSystem> ().Play ();

		var hitColliders = Physics.OverlapSphere (caster.transform.position, range);
		
		for (var i = 0; i < hitColliders.Length; i++) {
			if (hitColliders [i].tag == "Enemy") {
				hitColliders [i].gameObject.GetComponent<stats>().takeDamage(damage * spellLVL);
			}
		}

		aoe.Play ();
		StartCoroutine (autoDestroy (spell));
		return cd;
	}
}
