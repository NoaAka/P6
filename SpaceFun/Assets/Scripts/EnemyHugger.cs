using UnityEngine;
using System.Collections;

public class EnemyHugger : Enemy {
	
	
	void Start () {
		cap = 100;
		value = 20;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
		
		god = GameObject.FindWithTag ("GameController");
		player = GameObject.FindWithTag ("Player");
		scoreText = GameObject.Find ("Score");
	}
	
	void Update () {
		Death ();
		Debug.Log (charge);
		Follow (player);
	}
}
