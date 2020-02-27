using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointControl : MonoBehaviour {
	private GameObject Lastentry;
	private int obj;
	private bool finish = false;
	public GUISkin skin;
	// Use this for initialization
	void Start () {
		Lastentry = GameObject.FindGameObjectWithTag("Fake");
		obj = 0;
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(finish){
			GameObject.FindGameObjectWithTag("wall").SendMessage("Timeup");
			if(Input.GetButtonDown("Fire1")){
				Application.LoadLevel("Stage2_start");
			}
		}
	}

	void objControl(){
		obj += 1;
	}
	void OnTriggerEnter(Collider col){
		if(obj == 2 && GameObject.FindGameObjectWithTag("wall")){
			finish = true;
		}
	}
	void OnGUI(){
		GUI.skin = skin;

		int sw = Screen.width;
		int sh = Screen.height;

		if(finish){
			GUI.Label(new Rect(0,0,sw,sh),"STAGE1 CLEAR","text1");
			GUI.Label(new Rect(0,0,sw,sh),"\n\n 클릭하면 STAGE2로 갑니다.","text1");
		}
	}
}
