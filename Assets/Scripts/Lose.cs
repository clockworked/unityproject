using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {
	
	// Episode 22
	private int buttonWidth = 150;
	private int buttonHeight = 40;
	public Texture backgroundTexture;		// Episode 24
	private int gridX, gridY;

	void OnGUI () {	
		buttonWidth = (Screen.width / 5);
		buttonHeight = (Screen.height / 10);
		gridX = (Screen.width / 30);
		gridY = (Screen.height / 20);

		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
		if(GUI.Button (new Rect(gridX * 2,gridY * 15,buttonWidth,buttonHeight),"Play Again")){
			Debug.Log("Moving to Level 1...");
			// RESET ALL PLAYER STUFFS
			Application.LoadLevel(2);
		}
		
		if(GUI.Button (new Rect(gridX * 23,gridY * 15,buttonWidth,buttonHeight),"Main Menu")){
			Debug.Log("Moving to Main Menu...");
			Application.LoadLevel(1);
		}
	}
}
