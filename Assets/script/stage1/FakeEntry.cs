using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeEntry : MonoBehaviour {
	private GameObject entry;
	// Use this for initialization



	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "wall") {
		
			entry =GameObject.FindGameObjectWithTag("Fake");
			col.transform.position = entry.transform.position;
		
		}
		Debug.Log ("Fake");
	}

}
