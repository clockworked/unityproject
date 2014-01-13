using UnityEngine;
using System.Collections;

public class CourageItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider otherObject){					// When collding with other Object
		
		
		Debug.Log ("We hit:  " + otherObject.name);					// Prints to console
		
		if (otherObject.tag == "Player"){
			this.renderer.enabled = !this.renderer.enabled;
			
		}
	}
}
