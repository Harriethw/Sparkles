using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
namespace Assets.SimpleAndroidNotifications
{

public class CompManager : MonoBehaviour {

	private ComplimentStrings complimentStrings;
	public int eachBoolID;
	public List<int> repeatingIDList;
	private StartRepeatingButton startRepeatingButton;

	// Use this for initialization
	void Start () {
			complimentStrings = FindObjectOfType<ComplimentStrings>();
			startRepeatingButton = FindObjectOfType<StartRepeatingButton>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void Once()
		//sends one random string at random time
	{
			int randomstring = (UnityEngine.Random.Range (0, complimentStrings.compList.Count));
			var notificationParams = new NotificationParams {
				Id = UnityEngine.Random.Range (0, int.MaxValue),
				Delay = TimeSpan.FromSeconds (UnityEngine.Random.Range (14400, 43200)),
				Title = "Hi",
				Message = complimentStrings.compList[randomstring],
				Ticker = ":)",
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = NotificationIcon.Heart,
				SmallIconColor = new Color (0, 0.5f, 0),
				LargeIcon = "app_icon"
			};

		NotificationManager.SendCustom(notificationParams);
	}
			

		public void Repeating (){
			var isClicked = PlayerPrefsX.GetBool ("ClickedRepeating");
			if (isClicked) {
				Debug.Log ("sending out comps for each");
				repeatingIDList.Clear ();
				int compNumber = 0;
				foreach (string comp in complimentStrings.compList) {
					//this gets the index number of each comp;
					compNumber = complimentStrings.compList.IndexOf (comp);
					var notificationParams = new NotificationParams {
						Id = NotificationIdHandler.GetNotificationId (),
						//adds 1 to each int and then times it by the delay, so each string happens with delay between it;
						Delay = TimeSpan.FromSeconds ((compNumber + 1) * 18000),
						Title = "Hi",
						Message = comp,
						Ticker = ":)",
						Sound = false,
						Vibrate = true,
						Vibration = new[] { 500, 500, 500, 500, 500, 500 },
						Light = true,
						LightOnMs = 1000,
						LightOffMs = 1000,
						LightColor = Color.magenta,
						SmallIcon = NotificationIcon.Star,
						SmallIconColor = new Color (0f, 0.5f, 0f),
						LargeIcon = "app_icon",
						ExecuteMode = NotificationExecuteMode.Inexact,
						Repeat = true,
						RepeatInterval = TimeSpan.FromSeconds (UnityEngine.Random.Range (180000, 266400)) // Don't use short intervals as repeated notifications are always inexact

					};
					//add these IDs to a list and then turn it into an array,so that we cancel just these Ids later
					eachBoolID = notificationParams.Id;
					repeatingIDList.Add (eachBoolID);
					Debug.Log ("adding this id to list" + eachBoolID);
					int[] repeatingIDArray = repeatingIDList.ToArray ();
					PlayerPrefsX.SetIntArray ("RepeatingIDs", repeatingIDArray);
					NotificationManager.SendCustom (notificationParams);
				}

			}
			if (!isClicked) {
				
				Debug.Log ("stopping comps");
				//get the array and turn it into a list, and then for every id cancel it
				int [] repeatingIDArray = PlayerPrefsX.GetIntArray ("RepeatingIDs");
				foreach (int id in repeatingIDArray) {
					Debug.Log ("cancelling" + id);
					NotificationManager.Cancel (id);
					startRepeatingButton.Colour ();
				}
				//clears list
				repeatingIDList.Clear ();
			}
		}


		public void RescheduleRepeating(){
			Debug.Log ("cancel repeating");
			int [] repeatingIDArray = PlayerPrefsX.GetIntArray ("RepeatingIDs");
			foreach (int id in repeatingIDArray) {
				Debug.Log ("cancelling" + id);
				NotificationManager.Cancel (id);
			}
			//clears list
			repeatingIDList.Clear ();
			//goes back to reschedule
			Repeating();
		}

		public void CancelAll()
		{
			//cancels everything, and tells repeating button to go to red;
			NotificationManager.CancelAll();
			PlayerPrefsX.SetBool ("ClickedRepeating", false);
			startRepeatingButton.Colour ();
			Debug.Log ("cancelling all");
		}



}
}