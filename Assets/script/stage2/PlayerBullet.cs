using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour 
{
	public GameObject Bullet;
	public GameObject tank;

	private GameObject target;
	private Vector3 tarPos;
	private Transform spawn;

	private float elapsedTime = 2.0f;
	private float shootRate = 2.0f;
	private float curRotSpeed = 1.0f;
	private int health = 100;

	void Start(){
		spawn = gameObject.transform.GetChild(0).transform;
	}

	void Update(){
		elapsedTime += Time.deltaTime;
		GameObject bullet = Instantiate(Bullet, spawn.position, spawn.rotation);

		if(Input.GetKeyDown("space"))
		{
			if (elapsedTime >= shootRate)
			{
				//Reset the time
				elapsedTime = 0.0f;

				float dist = Vector3.Distance(tank.transform.position, transform.position);
				if(dist <= 20.0f){
					Quaternion turretRotation = Quaternion.LookRotation(tank.transform.position - spawn.position);
					spawn.rotation = Quaternion.Slerp(spawn.rotation, turretRotation, Time.deltaTime * curRotSpeed);
				}

				Instantiate(Bullet, spawn.position, spawn.rotation);
			}
		}
	
	}
	/*
	void OnCollisionEnter(Collision collision)
	{
		//Reduce health
		if (collision.gameObject.tag == "Bullet")
		{
			health -= 50;

			if (health <= 0)
			{
				Explode();
			}
		}
	}

	protected void Explode() // 죽을 때 
	{
		float rndX = Random.Range(3.0f, 5.0f);
		float rndZ = Random.Range(3.0f, 5.0f);

		for (int i = 0; i < 3; i++)
		{
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			rb.AddExplosionForce(2.0f, transform.position - new Vector3(rndX, 3.0f, rndZ), 0.5f, 0.5f);
			rb.velocity = transform.TransformDirection(new Vector3(rndX, 0.0f, rndZ));

		}

		Destroy(gameObject, 1.5f);
	}*/
}