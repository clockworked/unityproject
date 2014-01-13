using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	
	public float MinSpeed;
	public float MaxSpeed;
	
	private float currentSpeed;
	private float x, y, z;
	
	void Start () {
		
	SetPositionAndSpeed();				// sets enemy position and speed on start
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float amtToMove = currentSpeed * Time.deltaTime;
		transform.Translate (Vector3.down * amtToMove);
		
		if(transform.position.y <= -5){
			SetPositionAndSpeed ();
			
		}
	
	}
	
	public void SetPositionAndSpeed(){
		currentSpeed = Random.RandomRange(MinSpeed,MaxSpeed);		// Generates a random speed between min and max
		y = 7.0f;
		z = 0.0f;
		x = Random.RandomRange(-6f,6f);
		transform.position = new Vector3(x,y,z);
	}
}
