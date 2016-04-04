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
	public GameObject God;
	public float speed = 2f;
	public float rotSpeed = 5f;

	void Start () {
		player = GameObject.FindWithTag ("Player");
		God = GameObject.FindWithTag ("GameController");

	}
	
	void Update () {


	}

	public void Death (){
		//Debug.Log ("Blop");
		//Death
		if (charge > cap) {
			Debug.Log ("Boom!");
			God.GetComponent<God> ().intensity+=value;
			Instantiate(explosion, this.transform.position, this.transform.rotation);
			Destroy(this.gameObject);
		}
	}

	public void Aim (GameObject target){
		//var dir = target.transform.position - transform.position;
		//Debug.Log (target.transform);
		transform.LookAt (target.transform);
	}

	public void Fire(){
		if (Time.time > nextFire && shouldFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		} 
	}

	public void Follow (GameObject target){
		//Rotate
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), rotSpeed * Time.deltaTime);

		//Move
		transform.position += transform.forward * speed * Time.deltaTime;
	}
}
