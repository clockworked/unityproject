using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {
	public Texture backgroundTexture;

	void OnGUI () {	
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
		
		// If you would rather press any key to continue...
		if(Input.anyKeyDown)
			Application.LoadLevel(1);
	}
}