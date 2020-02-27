using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItem : MonoBehaviour {

	public GameObject item; 
	private float delay;
	private int count=0;
	// Use this for initialization
	void Start () {

		delay = 3.0f;

	}
	
	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Bullet2") {

			if (count != 4) {
				count++;
			} 
			else {


				//if (delay <= 0.0) {
					//transform.position = trash.transform.position; 

					Instantiate (item,transform.position,transform.rotation);

				//}

				Destroy (gameObject);
				count = 0;
			}

	}

	}
}