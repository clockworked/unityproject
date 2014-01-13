using UnityEngine;
using System.Collections;

public class FinalPanel : MonoBehaviour {
	
	public float speed;

	// Update is called once per frame
	void Update () {
		float amtToMove = speed * Time.deltaTime;
		transform.Translate(Vector3.up * amtToMove,Space.World);
		if(transform.position.y >= -3){
			Debug.Log("HEY WE ARE GONNA FALL");
			Player.falling = true;
		}
		
		
	}
}

