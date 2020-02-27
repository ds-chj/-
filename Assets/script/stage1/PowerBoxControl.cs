using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxControl : MonoBehaviour {
	private int count=0;
	private float elapsedTime = 0.0f;

	public GameObject target;
	public GameObject Bullet;
	private float curSpeed, targetSpeed;
	// Use this for initialization
	void Start () {
		
		targetSpeed = 50.0f;
	}

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= 2.0f){
			UpdateAttack();
		}
		
	}


	void UpdateAttack(){

		Vector3 AttckPosition =target.transform.position-transform.position;
		//Vector3 position = transform.position+AttackPosition;
		GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
		curSpeed = Mathf.Lerp(curSpeed,targetSpeed, 10.0f*Time.deltaTime);
		bullet.transform.Translate(AttckPosition * Time.deltaTime * curSpeed);
		elapsedTime = 0.0f;
	}


	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Bullet2") {

			if (count != 9) {
				count++;
			} 


			else {

				Destroy (gameObject);
				count = 0;
			}
		}

	}
}
