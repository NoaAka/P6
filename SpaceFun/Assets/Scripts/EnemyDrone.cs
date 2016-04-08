using UnityEngine;
using System.Collections;

public class EnemyDrone : Enemy {


	void Start () {
		cap = 500;
		value = 10;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
		
		god = GameObject.FindWithTag ("GameController");
		scoreText = GameObject.Find ("Score");

	}
	
	void Update () {
		Death ();
		Debug.Log (charge);
		Aim (player);
		Fire ();

	}
}
