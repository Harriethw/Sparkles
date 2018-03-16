using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartOnceButton : MonoBehaviour {
	
	//private Image theColor;
	//public bool isClicked;
	//public Color32 lightblue;
	//public Color32 lightgreen;
	public GameObject Sending;

	// Use this for initialization
	void Start () {
		//theColor = GetComponent<Image> ();
	//lightblue = new Color32(198, 226, 233, 255);
	//	lightgreen = new Color32 (241, 255, 196, 255);
	}
	
	public void Change (){
	//	if (!isClicked) {
			Debug.Log ("sending once");
			//isClicked = true;
			Sending.SetActive (true);
		
		}
		//else {
			//Debug.Log ("set to false");
			//theColor.color = lightblue; 
		//}

	}
//}
