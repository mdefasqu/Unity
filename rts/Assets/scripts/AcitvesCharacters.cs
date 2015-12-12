using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AcitvesCharacters : MonoBehaviour {

	public static AcitvesCharacters	instance{ get; private set;}
	
	private List<character>  characters;
	
	public void add_active(character active)
	{
		characters.Add (active);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}