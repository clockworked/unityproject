using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {
	
	public float speed;

	// Update is called once per frame
	void Update () {
		float amtToMove = speed * Time.deltaTime;
		transform.Translate(Vector3.up * amtToMove,Space.World);
		
		
	}
}
