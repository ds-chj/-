using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void PlayerPosition(){
		Vector3 GoTarget = target.transform.position - transform.position;
		transform.Translate (GoTarget*10.0f*Time.deltaTime);
		//transform.position=target.transform.position;

	}

}
