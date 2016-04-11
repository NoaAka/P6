using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int value;
    public GameObject model;
    public int charge;
    public int cap;
    public GameObject explosion;
    public Transform boomSpawn;
    public string name;
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
	public int damage = 0;

    [Range(0.0f, 1.0f)]
    public float pickupSpawnChance;
    public GameObject pickup;

    //private SimpleSpawner simpleSpawner;//JDebug

    protected void Start() {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        intensityText = GameObject.Find("Intensity");
        scoreText = GameObject.Find("Score");

        //simpleSpawner = GameObject.Find("SimpleSpawner").GetComponent<SimpleSpawner>();//JDebug
    }

    void Update() {


    }

	public void Death(int points) {
        //Debug.Log ("Blop");
        //Death
        if (charge > cap) {
            Debug.Log("Boom!");
            intensityText.GetComponent<Intensity> ().AddIntensity(value);
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

}
