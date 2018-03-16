using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.SimpleAndroidNotifications
{
public class ComplimentStrings : MonoBehaviour {


	public List<string> compList;
	public GameObject compspawn, compPanel;
	public GameObject compspawnbox;
	public Text compspawntext;
	public InputField wordtext; 
	private CompManager compManager;


	public void Awake (){
		compManager = FindObjectOfType<CompManager>();
	}

	// Use this for initialization
	public void Start () {
		//check to see if custom word added, if not just generate basic ones

	if (PlayerPrefs.HasKey("Comps")) {
			Debug.Log ("playerprefs found");
			GenerateCompsPrefs ();
			}
			else {
			Debug.Log ("no player prefs"); 
			GenerateComps ();
			}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GenerateComps (){
		//spawn the text boxes on first loading from the list
		foreach (string comp in compList) {
			compspawntext.text = comp;
			Instantiate (compspawnbox);
			}


	}

	public void GenerateCompsPrefs (){
		//spawn the text boxes from the array in the playerprefs

		string[] compArray = PlayerPrefsX.GetStringArray ("Comps");

		foreach (string comp in compArray) {
			compspawntext.text = comp;
			Instantiate (compspawnbox);
		}

		//and then set the playerprefs value to the list so the notifcations can pull from it
		compList = compArray.ToList (); 	
	}

	public void AddNew (){
		//add text from input field to list
		compList.Add (wordtext.text);
		//add text to the ui
		compspawntext.text = wordtext.text;
		Instantiate (compspawnbox);
		//then add it to the prefs;
		AddtoPrefs ();
		wordtext.text = "";

	}

	public void AddtoPrefs (){
		//convert the list to an array, save the list to playerprefs
		string[] compArray = compList.ToArray();
		PlayerPrefsX.SetStringArray ("Comps", compArray);
			var isclicked = PlayerPrefsX.GetBool ("ClickedRepeating");
			if (isclicked) {
				compManager.RescheduleRepeating ();
		
			}
		
	}


}
}
