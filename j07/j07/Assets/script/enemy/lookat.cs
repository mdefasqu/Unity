﻿using UnityEngine;
using System.Collections;

public class lookat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (GetComponentInParent<enemy>().validTarget.transform.position);
	}
}
