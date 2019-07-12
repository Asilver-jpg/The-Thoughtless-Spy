using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkyLight : MonoBehaviour {
	private Behaviour h;
	public bool lightOn = true;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("switchLight", 2.0f, 2.0f);
		h=(Behaviour)gameObject.GetComponent ("Halo");
	}
	
	void switchLight(){
		lightOn = !lightOn;
		if (lightOn) {
			GetComponent<Light>().intensity = 5;
			h.enabled = true;
		}
		else{
			GetComponent<Light>().intensity = 0;
			h.enabled = false;
	
	}
}
}
