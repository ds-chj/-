using UnityEngine;
using System.Collections;

public class PlayerTankController : MonoBehaviour
{
	public GUISkin skin;
	private bool finish = false;

    public GameObject Bullet;
	public Camera cam;

    private Transform bulletSpawnPoint;    
    private float curSpeed, targetSpeed, rotSpeed;
	public float turretRotSpeed = 10.0f;
	public float maxForwardSpeed = 50.0f;
    private float maxBackwardSpeed;
	private int health = 10;
	private int items=0;

    //Bullet shooting rate
    protected float shootRate;
    protected float elapsedTime = 0.0f;

    void Start()
    {
		enabled = true;
        //Tank Settings
        rotSpeed = 30.0f;
		maxBackwardSpeed = - maxForwardSpeed;

        //Get the turret of the tank
		bulletSpawnPoint = gameObject.transform.GetChild(0).transform;
    }

    void OnEndGame()
    {
        // Don't allow any more control changes when the game ends
        this.enabled = false;
    }

    void Update()
    {
        UpdateControl();
        UpdateWeapon();
		if(Input.GetButtonDown("Fire1")&&health ==0){
			Application.LoadLevel("Stage2");
		}
    }
    
    void UpdateControl()
    {
        //AIMING WITH THE MOUSE
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position + new Vector3(0, 0, 0));

        // Generate a ray from the cursor position
        Ray RayCast = cam.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        float HitDist = 0;

        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(RayCast, out HitDist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 RayHitPoint = RayCast.GetPoint(HitDist);

            Quaternion targetRotation = Quaternion.LookRotation(RayHitPoint - transform.position);
			bulletSpawnPoint.transform.rotation = Quaternion.Slerp(bulletSpawnPoint.transform.rotation, targetRotation, Time.deltaTime * turretRotSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            targetSpeed = maxForwardSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetSpeed = maxBackwardSpeed;
        }
        else
        {
            targetSpeed = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotSpeed * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0.0f);
        }

        //Determine current speed
        curSpeed = Mathf.Lerp(curSpeed, targetSpeed, 7.0f * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);    
    }

    void UpdateWeapon()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (elapsedTime >= shootRate)
            {
                elapsedTime = 0.0f;
				Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            }
        }
    }

	void OnCollisionEnter(Collision col){
		
		if (col.gameObject.tag == "Bullet") {
			health -= 1;
			Debug.Log(health);
			if(health <= 0){
				finish = true;
			}
		}
	}

	void OnGUI(){
		GUI.skin = skin;

		int sw = Screen.width;
		int sh = Screen.height;


		if(skin.name == "GUI2"){
			if(!finish){
				GUI.Label(new Rect(0,0,sw,sh),"생명:"+health,"text3");
			}else{
				GUI.Label(new Rect(0,0,sw,sh),"실패","text2");
				GUI.Label(new Rect(0,0,sw,sh),"\n\n마우스를 클릭하면 다시 시작.","text2");	
			}
		}

	}

	void Timeup(){
		enabled = false;
	}
}