using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour {
	
	public float distance;
	private bool isGrabbed;
	private RaycastHit hit;
	private Rigidbody grabbedObject;
	private bool release;
	public float speed;
	private List<GameObject> items;
	private int currItem;
	private GameObject hitItem;
	private Transform child;
	private Collider collide;
	private Vector3 smallScale;
	public bool book;
	bool open=false;
	bool primed=false;
	public AudioClip sound;
	// Use this for initialization
	public void switchKinematic(Rigidbody bod){
		bod.isKinematic = true;

	}
	void Start () {
		distance = 5.0f;
		isGrabbed = false;
		speed = 5.0f;
		release = false;
		items = this.GetComponent<items> ().item;
		currItem = this.GetComponent<items> ().currItem;
		book = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		Debug.DrawRay (Camera.main.transform.position, Camera.main.transform.forward * distance, Color.red, 0.5f);
		items = this.GetComponent<items> ().item;
		currItem = this.GetComponent<items> ().currItem;


		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, distance)) {
			if (hit.collider.tag == "throw" || hit.collider.tag == "small") {
				if (items [currItem].transform.GetChild (0).tag == "hands") {
					if (Input.GetMouseButtonDown (0) && !isGrabbed) {
						Debug.Log ("PICK");
						grabbedObject = hit.rigidbody;
						grabbedObject.isKinematic = true;
						grabbedObject.transform.SetParent (Camera.main.transform);
						release = true;
					}
				}
			} else if (hit.collider.tag == "pickUp" && !searchThrough (hit.collider.gameObject.GetComponentsInChildren<Transform> (), "small")) {
				if (Input.GetMouseButtonDown (0)) {
					if (hit.transform.gameObject.transform.GetChild (0).tag == "sGun") {
						hit.transform.gameObject.transform.rotation = new Quaternion (0, -30, 0, 1);
					}
					items.Add (hit.transform.gameObject);
					hitItem = hit.transform.gameObject;
					hit.transform.gameObject.tag = "Untagged";
					Destroy (hit.collider);
					child = this.transform.GetChild (1).transform;
					GameObject joeisgood = hit.transform.gameObject;
					hit.transform.parent = child.transform;
					joeisgood.transform.localPosition = new Vector3 (0, 0, 0);

					hit.transform.gameObject.transform.SetParent (this.transform.GetChild (1));
					hit.transform.gameObject.transform.position = new Vector3 (child.position.x, child.position.y, child.position.z);


					this.GetComponent<items> ().currItem = this.GetComponent<items> ().nrItems;
					this.GetComponent<items> ().switchItem (this.GetComponent<items> ().currItem);

				}	
			} else if (hit.collider.tag == "books") {
				if (Input.GetMouseButtonDown (0)) {
					if (book == false) {
						book = true;
					} else if (book == true) {
						book = false;
					}
				}
			} else if (hit.collider.tag == "grenade") {
				if (Input.GetMouseButtonDown (0)) {
					
					this.GetComponent<grenade> ().grenadeCount += 1;
				}
			} else if (hit.collider.tag == "elevator") {
				if (Input.GetMouseButtonDown (0)) {
					if (open == false) {
						hit.collider.transform.GetChild (0).transform.position = new Vector3 (0, -1, 33);
						open = true;
					} else if (open == true) {
						hit.collider.transform.GetChild (0).transform.position = new Vector3 (0, -1, 233);
						open = false;
					}
				}
			} else if (hit.collider.tag == "phone") {
				if (Input.GetMouseButtonDown (0)) {
					Destroy (hit.collider.gameObject);
			}
		}

		if(items[currItem].transform.GetChild(0).tag== "hands"){
			distance = 5;
		if (!Input.GetMouseButtonDown (0) && release == true) {
			isGrabbed = true;
			release = false;
		}
			if (isGrabbed && Input.GetMouseButtonDown (0)) {
				Debug.Log ("DRP");
				grabbedObject.transform.SetParent (null);
				grabbedObject.isKinematic = false;
				isGrabbed = false;
			} else if (isGrabbed && Input.GetMouseButtonDown (1)) {
				Debug.Log ("YYEEEET");
				Camera.main.transform.GetChild (0).GetComponent<Rigidbody> ().velocity = transform.forward * speed;
				grabbedObject.transform.SetParent (null);
				grabbedObject.isKinematic = false;
				isGrabbed = false;
			}
		}else if(items[currItem].transform.GetChild(0).tag== "sGun"){
			
			distance=20;
			if (hit.collider.tag == "huge") {
				
				if (Input.GetMouseButtonDown (0)) {
					print ("HUGE");
					hit.transform.gameObject.transform.localScale = new Vector3 (hit.transform.gameObject.transform.localScale.x / 4, hit.transform.gameObject.transform.localScale.y / 4, hit.transform.gameObject.transform.localScale.z / 4);
					hit.collider.tag = "normal";
					hit.rigidbody.isKinematic = false;
					Invoke ("switchKinematic(hit.rigidbody)", 1);
				}
			} else if (hit.collider.tag == "normal") {
				if (Input.GetMouseButtonDown (0)) { 
					hit.transform.gameObject.transform.localScale = new Vector3 (hit.transform.gameObject.transform.localScale.x / 4, hit.transform.gameObject.transform.localScale.y / 4, hit.transform.gameObject.transform.localScale.z / 4);
					hit.collider.tag = "small";
					hit.transform.gameObject.transform.GetChild (hit.transform.gameObject.transform.childCount - 1).tag="throw";
					hit.rigidbody.isKinematic = false;
				} else if (Input.GetMouseButtonDown (1)) {
					hit.transform.gameObject.transform.localScale = new Vector3 (hit.transform.gameObject.transform.localScale.x * 4, hit.transform.gameObject.transform.localScale.y * 4, hit.transform.gameObject.transform.localScale.z * 4);
					hit.collider.tag = "huge";
					hit.rigidbody.isKinematic = true;


				}
			} else if (hit.collider.tag == "small") {
				if (Input.GetMouseButtonDown (1)) {
					hit.transform.gameObject.transform.localScale = new Vector3 (hit.transform.gameObject.transform.localScale.x * 4, hit.transform.gameObject.transform.localScale.y * 4, hit.transform.gameObject.transform.localScale.z * 4);
					hit.collider.tag = "normal";
					hit.rigidbody.isKinematic = true;
			
			}
	}

			
				
}
}
	}

	public bool searchThrough(Transform[] allChildren, string str){
		bool answer = false;
		foreach (Transform child in allChildren) {
			if (child.tag == str) {
				answer = true;
			}
	
		
		}
		return answer;
	}
}