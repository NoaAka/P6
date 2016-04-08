using UnityEngine;
using System.Collections;

public class EnemyWall : Enemy {

	
	void Start () {
		cap = 500;
		value = 20;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
		
		god = GameObject.FindWithTag ("GameController");
		scoreText = GameObject.Find ("Score");
		
	}
	
	void Update () {
		Death ();
		Debug.Log (charge);

	}
}
