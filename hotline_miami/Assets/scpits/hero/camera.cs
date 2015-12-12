using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	public GameObject activePlayer;
	
	void Update()
	{
		Vector3 pos = activePlayer.transform.position;
		pos.z = -1;
		transform.position = pos;
	}
}
