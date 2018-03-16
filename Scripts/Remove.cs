using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.SimpleAndroidNotifications
{
public class Remove : MonoBehaviour {

	private ComplimentStrings complimentStrings;
	public Text thisText;
	public GameObject compSpawn;

	// Use this for initialization
	void Start () {
		complimentStrings = FindObjectOfType<ComplimentStrings>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RemoveComp(){
			Debug.Log ("remove called");
			//remove the string from list;
			complimentStrings.compList.Remove(thisText.text);
			//remove from playerprefs and cancels any notifications;
			complimentStrings.AddtoPrefs();
			//remove gameobject;
			Destroy(compSpawn);
			}

	
	}
}
