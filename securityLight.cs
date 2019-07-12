using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (SecurityPlayerSee.seePlayer) {
			GetComponent<Light> ().intensity = 2; 
		} else {
			GetComponent<Light> ().intensity = 0; 
		}
	}
}
