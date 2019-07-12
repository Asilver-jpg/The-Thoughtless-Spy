using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {
	public float delay=3f;
	float countdown;
	float destCount;

	bool hasExploded=false;
	public GameObject explode;
	public bool isOn = false;
	public bool isThrown=false;
	public float radius;
	public float force= 700f;
	public float grenadeCount=0;
	public float throwForce=40f;
	public GameObject grenadePrefab;
	private GameObject grenades;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		countdown = delay;	
		destCount = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (grenadeCount > 0) {
			if (Input.GetKeyDown (KeyCode.G)) {
				grenades = Instantiate (grenadePrefab, transform.position, transform.rotation);
				Rigidbody rb = grenades.GetComponent<Rigidbody> ();
				rb.AddForce (transform.forward * throwForce, ForceMode.VelocityChange);
				Debug.Log ("ISON");
				isOn = true;
				grenadeCount -= 1;
			}
		}
			if(isOn==true){
				
				countdown -= Time.deltaTime;
				Debug.Log (countdown);
				if (countdown <= 0f && hasExploded == false) {
					Debug.Log ("EXPLODE");
					Explode ();
					hasExploded = true;

				} else if (hasExploded == true) {
				
					destCount -= Time.deltaTime;
					if (destCount <= 0f) {
						Destroy (grenades);
						Destroy (explode);

					}
				} 
			


			}
	
		}

	void Explode(){
		Debug.Log ("EXPLODE");
	
	
			
		explode=Instantiate (explode, grenades.transform.position, grenades.transform.rotation);
		
		AudioSource source = grenades.GetComponent<AudioSource> ();
		source.Play ();
		Collider[] colliders = Physics.OverlapSphere (grenades.transform.position, radius);	
		foreach (Collider nearbyObject in colliders) {
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody> ();
			if (rb != null) {
				rb.AddExplosionForce(force, grenades.transform.position,radius);
			
			}
		
		}

	}
}
