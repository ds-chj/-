using UnityEngine;
using System.Collections;

public class Wander2 : MonoBehaviour 
{
	public GameObject player;
	public GameObject Bullet;

	protected GameObject[] pointList;
	private GameObject target;
    private Vector3 tarPos;
	private Vector3 playerPos;
	private Transform turret;
	private Transform spawn;

    private float movementSpeed = 10.0f;
    private float rotSpeed = 2.0f;
	private float curRotSpeed = 1.0f;
	private int rndIndex;

	private float elapsedTime = 0.0f;
	private float shootRate = 2.0f;
	private int health = 100;


	// Use this for initialization
	void Start () 
    {
		pointList = GameObject.FindGameObjectsWithTag("Wandar3");

		rndIndex = Random.Range(0, pointList.Length);
		target = pointList[rndIndex];
		tarPos = target.transform.position;

		turret = gameObject.transform.GetChild(0).transform;
		spawn = turret.GetChild(0).transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
		elapsedTime += Time.deltaTime;
		playerPos = player.transform.position;

        if(Vector3.Distance(tarPos, transform.position) <= 5.0f)
            NextPoint();


		float dist = Vector3.Distance(playerPos, transform.position);
		if(dist <= 10.0f){
			Attack();
		}

        Quaternion tarRot = Quaternion.LookRotation(tarPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);

        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));
	}

	void NextPoint(){
		rndIndex = Random.Range(0, pointList.Length);

		if(Vector3.Distance(pointList[rndIndex].transform.position, gameObject.transform.position) <= 5.0f){
			rndIndex = Random.Range(0, pointList.Length);
		}

		tarPos = pointList[rndIndex].transform.position;
	}

	void Attack(){
		Quaternion turretRotation = Quaternion.LookRotation(playerPos - turret.position);
		turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);

		//Shoot bullet towards the player
		ShootBullet();
	}

	public void ShootBullet()
	{
		if (elapsedTime >= shootRate)
		{
			Instantiate(Bullet, spawn.position, spawn.rotation);

			elapsedTime = 0.0f;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		//Reduce health
		if (collision.gameObject.tag == "Bullet2")
		{
			health -= 50;

			if (health <= 0)
			{
				Destroy(gameObject, 1.5f);
				//Explode();
			}
		}
	}

	protected void Explode()
	{
		float rndX = Random.Range(3.0f, 5.0f);
		float rndZ = Random.Range(3.0f, 5.0f);

		for (int i = 0; i < 3; i++)
		{
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			rb.AddExplosionForce(5.0f, transform.position - new Vector3(rndX, 3.0f, rndZ), 2.0f, 2.0f);
			rb.velocity = transform.TransformDirection(new Vector3(rndX, 2.0f, rndZ));

		}

		Destroy(gameObject, 1.5f);
	}
	void Timeup(){
		enabled = false;
	}
}
