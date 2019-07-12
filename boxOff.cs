using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Renderer>().enabled = false;

	}
}
