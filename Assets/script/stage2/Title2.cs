using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title2 : MonoBehaviour {
	public GUISkin skin;

	private int count = 0;
	// Use this for initialization
	void Start () {
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			count++;
			if(count==2)
				Application.LoadLevel("Stage2");
		}
	}

	void OnGUI(){
		GUI.skin = skin;

		int sw = Screen.width;
		int sh = Screen.height;

		if(count == 0){
			GUI.Label(new Rect(0,0,sw,sh),"STAGE2","text2");
			GUI.Label(new Rect(0,0,sw,sh),"\n\n 식물을 목표지점을 찾아 식물을 가져가세요.","text2");
		}
		else if(count == 1){
			GUI.Label(new Rect(0,0,sw,sh),"조작방법 : w,s,a,d로 이동 마우스 클릭 : 공격","text2");
			GUI.Label(new Rect(0,0,sw,sh),"\n\n마우스를 클릭하면 시작합니다.","text2");	
		}
	}
}
