using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour {
	public GUISkin skin;
	private float timer = 100.0f;

	// Use this for initialization
	void Start () {
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;;
	}

	void OnGUI(){
		GUI.skin = skin;

		int sw = Screen.width;
		int sh = Screen.height;

		float timeShow = timer;

		GUI.Label(new Rect(0,0,sw,sh),"time : " + string.Format("{0:N0}", timeShow) ,"time");
	}
}
