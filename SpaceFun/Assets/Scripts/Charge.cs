using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

	public int charge = 0;
	public int cap = 100;
	public GameObject explosion;
	public Transform boomSpawn;

	void Start () {
	
	}
	
	void Update () {
		//Debug.Log (charge);
		charge++;
		if (charge > cap) {
			Debug.Log ("Boom!");
			Instantiate(explosion, boomSpawn.position, boomSpawn.rotation);
			Destroy(this.gameObject);
		}
	}
}
