using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	// Episode 21
	private string instructionText = "UNCERTAIN.";
	private int buttonWidth = 150;
	private int buttonHeight = 40;
	public Texture backgroundTexture;
	private int gridX, gridY;
	

	void OnGUI () {	
		buttonWidth = (Screen.width / 5);
		buttonHeight = (Screen.height / 10);
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
		//GUI.Label(new Rect(10,10,300,200),instructionText);
		gridX = (Screen.width / 30);
		gridY = (Screen.height / 20);
		// Below is the code to transition scenes
		if(GUI.Button (new Rect(gridX * 2,gridY * 15,buttonWidth,buttonHeight),"Start Game")){
			Debug.Log("Moving to Level 1...");
			Application.LoadLevel(2);
		}

		if(GUI.Button (new Rect(gridX * 23,gridY * 15,buttonWidth,buttonHeight),"Credits")){
			Debug.Log("Moving to Credits...");
			Application.LoadLevel(5);
		}
		
		// If you would rather press any key to continue...
		//if(Input.anyKeyDown)
		//	Application.LoadLevel(1);
	}
}
