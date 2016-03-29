using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private InputControl input;
	public int speed = 4;
	public Rigidbody rb;
	public float turnSmooth = 15.0f;

	float moveH;
	float moveV;
	float rotH;
	float rotV;

	Vector3 movement;
	Vector3 targetDir;
	Quaternion targetRot;
	Quaternion finalRot;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1f;
	float nextFire = 0;

	void Start () {
		input = GameObject.Find ("InputControl").GetComponent<InputControl> ();
	}

	void Update()
	{
		//Fire
		if ((input.RH > 0.2f || input.RV > 0.2 || input.RH < -0.2 || input.RV < -0.2) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

		}
	}

	void FixedUpdate () {
		//Moving using Left Analog
		moveH = input.LH;
		moveV = input.LV;
		movement = new Vector3(moveH,0.0f,moveV);
		rb.velocity = movement * speed;

		//Rotating using Right Analog
		rotH = input.RH;
		rotV = input.RV;
		targetDir = new Vector3 (rotH, 0.0f, -rotV);
		targetRot = Quaternion.LookRotation (targetDir, Vector3.up);
		finalRot = Quaternion.Lerp (rb.rotation, targetRot, turnSmooth * Time.deltaTime);
		rb.MoveRotation (finalRot);
	}
}
