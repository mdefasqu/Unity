using UnityEngine;
using System.Collections;

public class spell5 : MonoBehaviour {

	public int spellLVL = 1;
	public int damage = 0;
	public int range = 8;
	public int cd = 0;
	public GameObject effect;
	public AudioSource thunder;

	public string getToolTip(){
		return ("Niveau du sort : "+spellLVL+
		        "\nDegats du sort : "+damage * spellLVL+
		        "\nUn eclaire de foudre s'abat instantanement sur l'ennemis lui infligeant "+damage * spellLVL+" degats");
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
		thunder.Play ();
		GameObject spell = Instantiate (effect, target.transform.position, Quaternion.identity) as GameObject;
		spell.GetComponent<ParticleSystem> ().Play ();
		target.GetComponent<stats> ().takeDamage (damage * spellLVL);
		StartCoroutine (autoDestroy (spell));
		return cd;
	}
}
