using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour {
	public List<GameObject> item;// for prefabs
	public int currItem=0;
	public int preItem=0;
	public int nrItems;
	public Renderer rend;
	private GameObject hand;

	// Use this for initialization
	void Start () {
		nrItems = item.Count;
		hand = GameObject.Find ("hands");
		item.Add (hand);
		switchItem (currItem);
	}
	
	// Update is called once per frame
	void Update () {
		
		nrItems = item.Count;
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			if (currItem + 1 > nrItems-1) {
				currItem = 0;
				switchItem (currItem);
			} else {
				currItem = currItem + 1;
				switchItem(currItem);
			}
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (currItem - 1 < 0) {
				currItem = nrItems-1;
				switchItem(currItem);
			}else{
				currItem = currItem - 1;
				switchItem(currItem);


			}
		}
	}
			
	public void switchItem(int index){
		
		if (index != preItem) {
			
			item [index].gameObject.GetComponent<Renderer>().enabled=true;
			item [preItem].gameObject.GetComponent<Renderer>().enabled=false;

			preItem = index;
		}
	}
}


