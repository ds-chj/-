using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemControl1 : MonoBehaviour {
	private float velocity = 6.0f;
	private float moveDelay = 1.0f;
	private float sustainTime = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "wall"){
			GameObject entry = GameObject.FindGameObjectWithTag("entry");
			entry.gameObject.SendMessage("objControl");

			Destroy(gameObject);
		}
	}
}
