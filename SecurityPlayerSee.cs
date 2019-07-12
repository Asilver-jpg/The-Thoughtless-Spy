using UnityEngine;
using System.Collections;
public class SecurityPlayerSee : MonoBehaviour
{
	public static bool seePlayer; // public static so it's easy to get from other scripts
	public int EvilRobotNum;
	public GameObject player; // don't forget to attach the player gameObject

	void Update()
	{
		// this uses colliders so put a small collider on the 1st person controller.
		if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(GetComponent <Camera >()), player.GetComponent<Collider >().bounds)) 
		{
			RaycastHit hit; 
			if (Physics.Linecast(transform.position, player.transform.position, out hit)) // returns true if there is a collider between two points. 
			{
				if(hit.collider.tag == "seePlayer"){
					seePlayer = true; 
				}
				else{
					seePlayer = false;
				}
			}
		}
		else // if we're not in view of the camera
		{
			seePlayer = false; 
		}	
	}
}