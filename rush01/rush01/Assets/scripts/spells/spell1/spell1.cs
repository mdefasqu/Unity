using UnityEngine;
using System.Collections;

public class spell1 : MonoBehaviour {

	public int spellLVL = 1;

	public string getToolTip(){
		return ("Niveau du sort : "+spellLVL+
		        "\nCourt Forest !!!");
	}

	public void upgradeSpell(){
		spellLVL += 1;
	}
	public int Cast(GameObject target, GameObject caster){
		caster.GetComponent<NavMeshAgent>().speed = 10 + 2 * spellLVL;
		return 0;
	}
}
