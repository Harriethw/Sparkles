using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartRepeatingButton : MonoBehaviour {
	//could do this by instead making an image active/inactive
	//this get the Transitions of the Button as its pressed
	private Image theColor;
	public Color32 lightblue;
	public Color32 lightgreen;
	public GameObject Sending;

	// Use this for initialization
	void Start () {
		theColor = GetComponent<Image> ();
		lightblue  = new Color32(198, 226, 233, 255);
		lightgreen = new Color32 (241, 255, 196, 255);
		Colour ();
	}

	public void Change (){
		var isClicked = PlayerPrefsX.GetBool ("ClickedRepeating");
		if (!isClicked) {
			PlayerPrefsX.SetBool ("ClickedRepeating", true);
			Debug.Log ("set to true");
			theColor.color = lightgreen;
			Sending.SetActive (true);
		}
		else {
			PlayerPrefsX.SetBool ("ClickedRepeating", false);
			Debug.Log ("set to false");
			theColor.color = lightblue; 
		}

	}

	public void Colour (){
		var isClicked = PlayerPrefsX.GetBool ("ClickedRepeating");
		if (!isClicked) {
			theColor.color = lightblue; 
		}
		else {
			theColor.color = lightgreen; 
		}
	}

	// Update is called once per frame
	void Update () {

	}
}


