using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour {

	public void DeletePlayerPrefs(){
		PlayerPrefs.DeleteAll ();
	}
}
