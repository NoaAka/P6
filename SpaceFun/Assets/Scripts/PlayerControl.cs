using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private InputControl input;
    private God god;
	public int speed = 4;
	public Rigidbody rb;
	public float turnSmooth = 15.0f;

	float moveH;
	float moveV;
	float rotH;
	float rotV;

	public bool shouldFire = true;

	Vector3 movement;
	Vector3 targetDir;
	Quaternion targetRot;
	Quaternion finalRot;

    public GameObject explosion;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1f;
	float nextFire = 0;

    //playership
    private GameObject playerShip;

    //playershield
    public float shieldPower = 50f;
    private bool shieldActive;
    private GameObject playerShield;

    private AnimationController animationController;
    public float xMin, xMax, zMin, zMax;

    void Start () {
		input = GameObject.FindWithTag ("InputControl").GetComponent<InputControl> ();
        god = GameObject.FindWithTag("GameController").GetComponent<God>();

        //playerShip 
        playerShip = GameObject.FindGameObjectWithTag("PlayerShip");

        //shield 
        animationController = GetComponentInChildren<AnimationController>();
        playerShield = GameObject.FindGameObjectWithTag("PlayerShield");
        if (shieldPower > 0f)
        {
            ActivateShield();
        }
        else
        {
            DissactivateShield();
        }
    }

	void Update()
	{
		//Fire
		if ((input.RH > 0.2f || input.RV > 0.2 || input.RH < -0.2 || input.RV < -0.2) && Time.time > nextFire && shouldFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			rb.velocity = new Vector3 (0f, 0f, 0f);
		} else if (input.RH > 0.2f || input.RV > 0.2 || input.RH < -0.2 || input.RV < -0.2) {
			rb.velocity = new Vector3 (0f, 0f, 0f);
		}

        //shield or not

        animationController.ShieldLevel((int)shieldPower);//render shield
        if(shieldActive && shieldPower < 1f)
        {     
            DissactivateShield();  
        }
        else if (!shieldActive && shieldPower > 0f)
        {
            ActivateShield();
        }

        //Clamp shield
        if(shieldPower >= 1000f)
        {
            shieldPower = 1000f;
        }
        god.shield = shieldPower;
    }

	void FixedUpdate () {
		//Moving using Left Analog
		moveH = input.LH;
		moveV = input.LV;
		movement = new Vector3(moveH,0.0f,moveV);
		rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, xMin, xMax),
            0f,
            Mathf.Clamp(rb.position.z, zMin, zMax)
        );

		//Rotating using Right Analog
		rotH = input.RH;
		rotV = input.RV;
		targetDir = new Vector3 (rotH, 0.0f, -rotV);
        if (input.RH > 0.2f || input.RV > 0.2 || input.RH < -0.2 || input.RV < -0.2) {
			targetRot = Quaternion.LookRotation (targetDir, Vector3.up);
			finalRot = Quaternion.Lerp (rb.rotation, targetRot, turnSmooth * Time.deltaTime);
			rb.MoveRotation (finalRot);
		}

	}

    void OnTriggerEnter(Collider other)
    {
        //Pickup
        if (other.gameObject.tag == ("Pickup"))
        {
            //print("pickup!!!! ");
            shieldPower += other.transform.parent.gameObject.GetComponent<Pickup>().energy*god.revIntMultiplier;
            god.shield = shieldPower;
            Destroy(other.transform.parent.gameObject);
        }
		/*
        else {
            print("Player Collided with " + other);
            if (shieldActive)
            {
                if (other.gameObject.GetComponent<Damage>() != null)
                {//should be cached?! check to see if other can give damage.. 
                    shieldPower -= other.gameObject.GetComponent<Damage>().damage;
                }


                Destroy(other.gameObject);
            }
            else
            {
                playerShip.SetActive(false);//make new method PlayerDeath() ,time out and restart? 
            }
        }*/
    }
    void DissactivateShield() {
        shieldPower = 0;
        shieldActive = false;
        playerShield.GetComponent<CapsuleCollider>().enabled = false;//can be cached?!
        playerShip.GetComponent<CapsuleCollider>().enabled = true;
        animationController.TurnOff();


    }
    void ActivateShield() { 
        shieldActive = true;
        playerShield.GetComponent<CapsuleCollider>().enabled = true;
        playerShip.GetComponent<CapsuleCollider>().enabled = false;
        animationController.TurnOn();

    }
	
}

