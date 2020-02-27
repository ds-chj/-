using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {
	public GUISkin skin;
	void OnGUI() {
		GUI.skin = skin;
		if (GUI.Button (new Rect ((Screen.width / 2)-70, (Screen.height / 2) , 150, 100), "game start")) {
			Application.LoadLevel ("stage1_start");
		}
	}

	// Use this for initialization
	void Start () {
		enabled = true;
	}

	// Update is called once per frame
	void Update () {

	}
}
