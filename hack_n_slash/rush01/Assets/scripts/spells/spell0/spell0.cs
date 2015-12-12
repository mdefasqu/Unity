using UnityEngine;
using System.Collections;

public class spell0 : MonoBehaviour {

	public int spellLVL = 0;
	public int damages = 0;
	public int range = 0;
	public int cd = 0;
	public GameObject effect;
	public AudioSource Sound;

	// Use this for initialization

	public string getToolTip(){
		return ("Niveau du sort : "+spellLVL+
		        "\nDegats du sort : "+damages* spellLVL+
		        "\nSort de boule de feu Kikou !");
	}

	IEnumerator autoDestroy(GameObject spell){
		yield return new WaitForSeconds (10);
		Destroy (spell);
	}

	public void upgradeSpell(){
		spellLVL += 1;
	}

	public int Cast(GameObject target, GameObject caster){
		Sound.Play ();
		GameObject spell = Instantiate (effect, caster.transform.position, Quaternion.identity) as GameObject;
		spell.transform.LookAt (target.transform.position);
		spell.transform.GetChild(0).GetComponent<Spell0particle> ().damage = damages * spellLVL;
		StartCoroutine (autoDestroy (spell));
		return cd;
	}
}
