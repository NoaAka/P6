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

	void Start () {
	
	}
	
	void Update () {
	
		//Death
		if (charge > cap) {
			Debug.Log ("Boom!");
			Instantiate(explosion, boomSpawn.position, boomSpawn.rotation);
			Destroy(this.gameObject);
		}
	}
}
