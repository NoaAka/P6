using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int value;
    public int charge;
    public int cap;
    public GameObject explosion;
    public Transform boomSpawn;
    public Rigidbody rb;
    public GameObject player;
    public bool shouldFire = true;
    public GameObject shot;
    public Transform shotSpawn;
    public Transform playerTrans;
    public float fireRate = 1f;
    float nextFire = 0;
    public GameObject intensityText;
    public GameObject scoreText;
    public float speed = 2f;
    public float rotSpeed = 5f;
	public float damage = 0f;

    [Range(0.0f, 1.0f)]
    public float pickupSpawnChance;
    public GameObject pickup;
	private God god;

    //private SimpleSpawner simpleSpawner;//JDebug

	protected void Start() {
		god = GameObject.FindWithTag ("GameController").GetComponent<God> ();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        intensityText = GameObject.Find("Intensity");
        scoreText = GameObject.Find("Score");

        //simpleSpawner = GameObject.Find("SimpleSpawner").GetComponent<SimpleSpawner>();//JDebug
    }

	public void Death(int points, int intensity) {
        //Debug.Log ("Blop");
        //Death
        if (charge > cap) {
            //Debug.Log("Boom!");
			float intpass = intensity;
			intensityText.GetComponent<Intensity> ().AddIntensity(intpass*god.intMultiplier);
			scoreText.GetComponent<Score> ().AddPoints (points);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            GeneratePickup();

            //if (transform.gameObject.name.StartsWith("EnemyDrone")) simpleSpawner.SpawnEnemy();//JDebug
        }
    }

    public void Aim(GameObject target) {
        //var dir = target.transform.position - transform.position;
        //Debug.Log (target.transform);
        transform.LookAt(target.transform);
    }

    public void Fire() {
        if (Time.time > nextFire && shouldFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    public void Follow(GameObject target) {
        //Rotate
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotSpeed * Time.deltaTime);

        //Move
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    public void GeneratePickup()
    {
        //based on pickup chance 
        if (Random.value < pickupSpawnChance || pickupSpawnChance == 1)
        {
            float yOffset = 8;
            Instantiate(pickup, new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z), Quaternion.identity);
        }
    }
	public void OnCollisionEnter(Collision hit){
		//Debug.Log (hit.gameObject.tag);
		//Debug.Log (this.gameObject.name);
		if ((this.gameObject.name == "EnemyHugger(Clone)" || this.gameObject.name == "EnemyBolt(Clone)") && (hit.gameObject.tag == "PlayerShip" || hit.gameObject.tag == "PlayerShield" || hit.gameObject.tag == "Player")) {
			//Debug.Log ("Working: "+this.gameObject.name);
			if (hit.gameObject.GetComponent<PlayerControl> ().shieldPower < 0) {
				Debug.Log ("Player Lost!");
				charge = cap + 1;
				Death (0, -value);
			} else {
				int d = (int) Mathf.Round(damage+damage*god.intMultiplier);
				hit.gameObject.GetComponent<PlayerControl> ().shieldPower -= d;
                god.shield = (int)hit.gameObject.GetComponent<PlayerControl>().shieldPower;
                Debug.Log (d+" damage on hit");
				charge = cap + 1;
				Death (0, -value);
				//Debug.Log ("Damage to " + hit.gameObject.name);
			}
		} else if (this.gameObject.name == "EnemyBolt(Clone)") {
			//Makes bolts die when they hit something to prevent them clogging up the field
			//Issue: They die when fired, due to collision with the drone
			/*
			charge = cap + 1;
			Debug.Log ("Bolt collision");
			Death (0, -0);*/
		}
	}

}
