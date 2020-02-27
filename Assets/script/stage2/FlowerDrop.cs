using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDrop : MonoBehaviour {
	private bool finish;
	public GUISkin skin;
	// Use this for initialization
	void Start () {
		enabled = true;	
		finish = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")&&finish){
			Application.LoadLevel("Stage1_start");
		}
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "wall"){
			GameObject shoes = GameObject.FindGameObjectWithTag("shoes");
			GameObject finishPos = GameObject.FindGameObjectWithTag("fpos");
			GameObject Tank = GameObject.FindGameObjectWithTag("Tank");

			Vector3 shoesPos = shoes.transform.position;
			Vector3 fPos = finishPos.transform.position;
			float dist = Vector3.Distance(shoesPos, fPos);

			shoes.transform.position= Vector3.Lerp(shoesPos, fPos, dist);
			shoes.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
			col.gameObject.SendMessage("Timeup");
			Tank.gameObject.SendMessage("Timeup");

			finish = true;
		}
	}

	void OnGUI(){
		GUI.skin = skin;

		int sw = Screen.width;
		int sh = Screen.height;

		if(finish){
			GUI.Label(new Rect(0,0,sw,sh),"STAGE2 CLEAR","text2");
			GUI.Label(new Rect(0,0,sw,sh),"\n\n마우스를 클릭하면 메인으로 갑니다.","text2");	
		}
	
	}
}

