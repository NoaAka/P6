//This script is based on the following tutorial:
//https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/fun-with-lasers

using UnityEngine;
using System.Collections;

public class LaserWheelModule : MonoBehaviour {
	
	private InputControl input;
	private LaserWheel master;
	LineRenderer line;
	public int length = 100;
	public int force = 5;
	public int damage = 10;
	public bool shouldFire = true;
	
	void Start () {
		input = GameObject.FindWithTag ("InputControl").GetComponent<InputControl> ();
		master = GameObject.Find ("LaserWheel").GetComponent<LaserWheel> ();
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = false;
	}

	//Damagin Ray
	IEnumerator FireLaser(){
		line.enabled = true;

		//Player's beam
		while ((input.RS > 0.2) && shouldFire && master.wheelFuel > 0) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			line.SetPosition (0, ray.origin);

			//Checks if anything blocks the laser
			if (Physics.Raycast (ray, out hit, length)) {
				line.SetPosition (1, hit.point);
				if (hit.collider.tag == "Enemy") {
					Debug.Log ("Hit!");
					switch (hit.collider.name) {
					case "EnemyDrone(Clone)":
						Debug.Log ("Drone Hit");
						hit.collider.gameObject.GetComponent<EnemyDrone> ().charge += damage;
						break;
					case "EnemyWall(Clone)":
						Debug.Log ("Wall Hit");
						hit.collider.gameObject.GetComponent<EnemyWall> ().charge += damage;
						break;
					case "EnemyHugger(Clone)":
						Debug.Log ("Hugger Hit");
						hit.collider.gameObject.GetComponent<EnemyHugger> ().charge += damage;
						break;
					case "Bolt(Clone)":
						Debug.Log ("Bolt Hit");
						hit.collider.gameObject.GetComponent<EnemyBolt> ().charge += damage;
						break;
					}
				}
			} else {
				//Shoots laser whole duration if nothing blocks it.
				//If laser should go through objects, use only this line
				line.SetPosition (1, ray.GetPoint (length));
			}
			yield return null;
		}
		line.enabled = false;
	}

	//Pushing Ray
	/*
	IEnumerator FireLaser(){
		line.enabled = true;
		while ((input.RS > 0.2) && shouldFire) {
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			
			line.SetPosition(0, ray.origin);
			
			//Checks if anything blocks the laser
			if(Physics.Raycast (ray, out hit, length)){
				line.SetPosition(1, hit.point);
				if(hit.rigidbody){
					hit.rigidbody.AddForceAtPosition(transform.forward * force, hit.point);
				}
			}
			else{
				//Shoots laser whole duration if nothing blocks it.
				//If laser should go through objects, use only this line
				line.SetPosition(1, ray.GetPoint(length));
			}
			
			yield return null;
		}
		line.enabled = false;
	}*/
}
