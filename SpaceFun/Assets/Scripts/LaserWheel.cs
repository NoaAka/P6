//This script is based on the following tutorial:
//https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/fun-with-lasers

using UnityEngine;
using System.Collections;

public class LaserWheel : MonoBehaviour {
	
	private InputControl input;
	public int rotSpeed = 200;
	public int masterLength = 7;
	public int masterForce = 5;
	public bool masterShouldFire = true;
	public GameObject left, right, front, back;
	public GameObject player;
	
	void Start () {
		input = GameObject.FindWithTag ("InputControl").GetComponent<InputControl> ();
	}
	
	void FixedUpdate () {
		this.transform.position = player.transform.position;
		this.transform.Rotate (0, Time.deltaTime * rotSpeed, 0);

		left.GetComponent<LaserWheelModule>().length = masterLength;
		right.GetComponent<LaserWheelModule>().length = masterLength;
		front.GetComponent<LaserWheelModule>().length = masterLength;
		back.GetComponent<LaserWheelModule>().length = masterLength;
		
		left.GetComponent<LaserWheelModule>().force = masterForce;
		right.GetComponent<LaserWheelModule>().force = masterForce;
		front.GetComponent<LaserWheelModule>().force = masterForce;
		back.GetComponent<LaserWheelModule>().force = masterForce;

		left.GetComponent<LaserWheelModule>().shouldFire = masterShouldFire;
		right.GetComponent<LaserWheelModule>().shouldFire = masterShouldFire;
		front.GetComponent<LaserWheelModule>().shouldFire = masterShouldFire;
		back.GetComponent<LaserWheelModule>().shouldFire = masterShouldFire;

		if ((input.RS > 0.2) && masterShouldFire) {
			Debug.Log ("Fire!");
			left.GetComponent<LaserWheelModule>().StopCoroutine ("FireLaser");
			right.GetComponent<LaserWheelModule>().StopCoroutine ("FireLaser");
			front.GetComponent<LaserWheelModule>().StopCoroutine ("FireLaser");
			back.GetComponent<LaserWheelModule>().StopCoroutine ("FireLaser");
			left.GetComponent<LaserWheelModule>().StartCoroutine ("FireLaser");
			right.GetComponent<LaserWheelModule>().StartCoroutine ("FireLaser");
			front.GetComponent<LaserWheelModule>().StartCoroutine ("FireLaser");
			back.GetComponent<LaserWheelModule>().StartCoroutine ("FireLaser");
			//StartCoroutine ("FireLaser");
		}
	}
}
