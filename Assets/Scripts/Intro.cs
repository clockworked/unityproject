using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	public Texture image1;
//	public Texture2D[] images = new Texture[image1,image2,image3];
	public Texture current;
	

	void OnGUI () {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),image1);
		StartCoroutine(sequence());
		
	}
	
	
		IEnumerator sequence(){								
				yield return new WaitForSeconds(2);
				Application.LoadLevel(1);
			}
			
//		}

}

