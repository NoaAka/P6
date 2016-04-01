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
	public float fireRate = 1f;
	float nextFire = 0;

	void Start () {
		 
	}
	
	void Update () {
		player = GameObject.FindWithTag ("Player");


	}

	public void Death (){
		Debug.Log ("Blop");
		//Death
		if (charge > cap) {
			Debug.Log ("Boom!");
			Instantiate(explosion, this.transform.position, this.transform.rotation);
			Destroy(this.gameObject);
		}
	}

	public void Aim (GameObject target){
		var dir = target.transform.position - transform.position;
		transform.LookAt (target.transform.position);
		Debug.Log (target.transform.position);
	}

	public void Fire(){
		if (Time.time > nextFire && shouldFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		} 
	}
}
