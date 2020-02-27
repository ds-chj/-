using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour {
	public GUISkin skin;
	private bool finish = false;
	// Use this for initialization
	void Start () {
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IsFinish(){
		
	}

	void OnGUI(){
		GUI.skin = skin;

		int sw = Screen.width;
		int sh = Screen.height;

		if(!finish){
			GUI.Label(new Rect(0,0,sw,sh),"생명:","text2");
			GUI.Label(new Rect(0,0,sw,sh),"\n\n 식물을 목표지점을 찾아 식물을 가져가세요.","text2");
		}
	}
}
