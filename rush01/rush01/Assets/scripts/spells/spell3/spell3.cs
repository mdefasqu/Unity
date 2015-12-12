using UnityEngine;
using System.Collections;

public class spell3 : MonoBehaviour {


	public int spellLVL = 1;
	public int HealPercent = 0;
	public int range = 0;
	public int cd = 0;
	public GameObject effect;
	public AudioSource heal;

	public void upgradeSpell(){
		spellLVL += 1;
	}

	public string getToolTip(){
		return ("Niveau du sort : "+spellLVL+
		        "\nSoins : "+HealPercent * spellLVL+
		        "%\nSoin instantatne");
	}

	IEnumerator autoDestroy(GameObject spell){
		yield return new WaitForSeconds (10);
		Destroy (spell);
	}

	public int Cast(GameObject target, GameObject caster){
		heal.Play ();
		GameObject spell = Instantiate (effect, caster.transform.position, Quaternion.identity) as GameObject;
		caster.GetComponent<stats>().life += (caster.GetComponent<stats>().hp * (HealPercent * spellLVL))/100;
		StartCoroutine (autoDestroy (spell));
		return cd;
	}
}
