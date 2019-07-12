using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookRotate : MonoBehaviour {
	public GameObject player; 
	private bool book;
	private Quaternion vec;
	private bool turned;
	private Quaternion ret;
	// Use this for initialization
	void Start () {
		book = false;

		turned = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		book = player.GetComponent<playerRaycast> ().book;
		if (book == true) {
			transform.rotation = Quaternion.Slerp (transform.rotation, vec, Time.deltaTime * 1);
			turned = true;
		} else if (book == false && turned == true) {
			transform.rotation = Quaternion.Slerp (transform.rotation, ret, Time.deltaTime * 1);
		}
	}
}
