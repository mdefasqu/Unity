using UnityEngine;
using System.Collections;

public class spell2 : MonoBehaviour {

	public int spellLVL = 1;
	public int damagesXsec = 0;
	public int range = 0;
	public int cd = 0;
	public GameObject effect;
	public AudioSource aoe;

	private bool isActive = false;
	private Vector3 mousePos;
	private GameObject spell = null;


	public string getToolTip(){
		return ("Niveau du sort : "+spellLVL+
		        "\nDegats du sort : "+damagesXsec * spellLVL+
		        "\nUne pluie de feu s'abat sur les ennemis infligeant "+damagesXsec * spellLVL+" degats toutes les secondes pendants 10 sec");
	}

	public void upgradeSpell(){
		spellLVL += 1;
	}

	IEnumerator autoDestroy(GameObject spell){
		yield return new WaitForSeconds (10);
		Destroy (spell);
	}

	public int Cast(GameObject target, GameObject caster){
		Debug.Log ("ici" + mousePos);
		spell = Instantiate (effect, mousePos, Quaternion.identity) as GameObject;
		spell.GetComponent<spell2Particle> ().damage = damagesXsec * spellLVL;
		isActive = true;
		return cd;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Ray cursorRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (cursorRay.origin, cursorRay.direction, out hit, 200)) {
			mousePos = hit.point;
		}

		if (isActive) {
			aoe.Play();
			spell.transform.position = mousePos;
			if(Input.GetKeyDown(KeyCode.Mouse0)){
				spell.GetComponent<spell2Particle>().ActiveSpell();
				spell.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
				spell.GetComponent<MeshRenderer>().enabled = false;
				isActive = false;
			}
		}
	}
}
