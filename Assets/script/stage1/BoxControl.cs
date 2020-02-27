using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour {
	private int count=0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Bullet2") {

			if (count != 4) {
				count++;
			} 
			else {

				Destroy (gameObject);
				count = 0;
			}
		}

	}


}