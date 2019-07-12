using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookShelf : MonoBehaviour {
	public GameObject player;
	private Rigidbody rb;
	public bool book;
	private bool swing;
	private JointSpring spring;
	private HingeJoint hinge;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
		swing = false;
		hinge = GetComponent<HingeJoint> ();
		spring = hinge.spring;
	}
	
	// Update is called once per frame
	void Update () {
		book = player.GetComponent<playerRaycast> ().book;
		if (book == true) {
			rb.freezeRotation = false;
			rb.AddTorque (Vector3.up * 50);
			swing = true;
			hinge.useSpring = false;
		
		
		} else if (book == false && swing == true) {
			spring.spring=10;
			spring.damper = 3;
			spring.targetPosition = 0;
			hinge.spring = spring;
			hinge.useSpring = true;
			float dist = transform.rotation.y - 176;
			print (dist);
			if (dist ==-175) {
				rb.freezeRotation = true;
				swing = false;
			} 
		}
		
	}
}
