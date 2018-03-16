using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CompSpawn : MonoBehaviour {

	public GameObject compPanel;
	//public Text text;


	// Use this for initialization
	public void Start () {
		compPanel = GameObject.Find ("CompPanel");
		this.transform.SetParent (compPanel.transform, false);
		//transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);

		//text = GameObject.Find("CompSpawn(Clone)").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
