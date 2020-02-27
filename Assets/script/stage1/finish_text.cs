using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish_text : MonoBehaviour {
	public GUISkin skin;
	// Use this for initialization
	void Start () {
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag("wall").SendMessage("Timeup");
		if(Input.GetButtonDown("Fire1")){
			Application.LoadLevel("Stage2_start");
		}
	}

	void OnGUI(){
		GUI.skin = skin;

		int sw = Screen.width;
		int sh = Screen.height;

		GUI.Label(new Rect(0,0,sw,sh),"STAGE1 CLEAR","text1");
		GUI.Label(new Rect(0,0,sw,sh),"\n\n 클릭하면 STAGE2로 갑니다.","text1");
	}

	void time(){
		enabled = true;
	}
}
