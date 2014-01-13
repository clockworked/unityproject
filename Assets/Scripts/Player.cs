using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {		
	
	enum State								
	{
		Start,
		Playing,
		Invincible,
		End
	}
	
	private State state = State.Playing;
	public float playerSpeed;
	public float rotationSpeed;
	public int bleed;
	private Transform myTransform;		
	public static int courage = 50; 	
	public static bool falling;
	private float onToScreenSpeed = 5;
	private float offScreenSpeed = 2;
	private float blinkRate = .1f;
	private int numberofTimesToBlink = 10;
	private int blinkCount;
	private Animator animator;
	
	 
	  IEnumerator Start () {
		state = State.Start;
		falling = false;
		animator = GetComponent<Animator>();
		courage = 50; 
		myTransform = transform;
		// Falling onto the screen on start
		transform.position = new Vector3(0f,8.22f,transform.position.z);	
		while (transform.position.y >= 2){
				float amtToMove = onToScreenSpeed * Time.deltaTime;
				transform.position = new Vector3(0f,transform.position.y - amtToMove, transform.position.z);
				yield return new WaitForSeconds(0);
		}
		state = State.Playing;
		
		StartCoroutine(CourageDecrease());
	
	}
	
	void Update () {
		
		
		float amtToMove = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;
		myTransform.Translate(Vector3.right * amtToMove); // Causes object to translate where they are based on current position
		if (falling == true || courage <= 0) state = State.End;
		if(state != State.Start || state!= State.End){
			// Sets up horizontal bounds
			if(myTransform.position.x <= -5.2f){
				myTransform.position = new Vector3(-5.2f,transform.position.y,transform.position.z);
			}
			else if ( myTransform.position.x >= 4.5f){
				myTransform.position = new Vector3(4.5f,transform.position.y,transform.position.z);
			}
				
			// Sets up Vertial bounds
			
		else if (state == State.End){
				StartCoroutine(Falling());
			}
		}

		// Below deals with switching the animations. Input.GetAxisRaw("Horizontal") returns -1 for left, 1 for right.
		// It loops to make sure the conditions get checked 9 times a seconds. 
		for(int i =0; i <10;i++){
			animator.SetInteger ("direction",(int)Input.GetAxisRaw("Horizontal"));
		}


		
		// This can be used for later inputs. 
		
		if (Input.GetKeyDown("space")){
		
				// do stuff
			}
		}
		
	
		// This is what slowly decreases your courage. 
		IEnumerator CourageDecrease () {
		if(Player.courage > 0){
			while (state == State.Playing){
			courage--;
			Debug.Log("Courage--. Current Courage " + courage);
			yield return new WaitForSeconds(bleed);
			}
		}
	}
	
		// This ends the level 
		IEnumerator Falling () {
			Debug.Log("Falling hit");
			while (transform.position.y >= -7){
				Debug.Log("Inside loop");
				float amtToMove = offScreenSpeed * Time.deltaTime;
				transform.position = new Vector3(transform.position.x,transform.position.y - amtToMove, transform.position.z);
				yield return new WaitForSeconds(0);
		}
		if(courage>25)Application.LoadLevel(4);
		else Application.LoadLevel (3);
	
	}
	
	
		// When colliding with other objects
		void OnTriggerEnter(Collider otherObject){			
	
		
		Debug.Log ("We hit:  " + otherObject.name);	
			
		if (otherObject.tag == "enemy" && state == State.Playing){
			Player.courage = courage - 10;						// If the player hits a nightmare objects, courage goes down by 10.
			Debug.Log("We've been hit!"  + "Current Courage: " + Player.courage);
			StartCoroutine(Blink());							// Make player invuln for a couple seconds
			
		}
		
		if (otherObject.tag == "courage" && state == State.Playing){
			Player.courage = courage + 10;							// If the player hits a courage objects, courage goes up by 10.
			Debug.Log("We got a courage item!"  + "Current Courage: " + Player.courage);
			otherObject.renderer.enabled = !otherObject.renderer.enabled;
			StartCoroutine(CourageDecrease());
		}
	}
	
	// Reused code from tutorial to make girl blink while invuln.
	IEnumerator Blink(){								
		if (Player.courage > 0){
			state = State.Invincible;
			
			while (blinkCount < numberofTimesToBlink){
				gameObject.renderer.enabled = !gameObject.renderer.enabled;	
				if (gameObject.renderer.enabled == true) blinkCount++;
				yield return new WaitForSeconds(blinkRate);
			}
			blinkCount = 0;
			state = State.Playing;
			StartCoroutine(CourageDecrease());
		}
		else
			Player.falling = true;
	}



}
