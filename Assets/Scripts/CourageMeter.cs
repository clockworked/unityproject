using UnityEngine;
using System.Collections;

public class CourageMeter : MonoBehaviour {
	
	
	public Texture courage1, courage2, courage3, courage4;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Player.courage < 100 && Player.courage > 75){
			renderer.material.SetTexture("_MainTex",courage4);
		}
		else if(Player.courage <= 75 && Player.courage > 50){
			renderer.material.SetTexture("_MainTex",courage3);
		}
		else if(Player.courage <= 50 && Player.courage > 25){
			renderer.material.SetTexture("_MainTex",courage2);
		}
		else if(Player.courage < 25) {
			renderer.material.SetTexture("_MainTex",courage1);
		}
		else{
			//LOSING CASE
		}
		
	
	}
}
