using UnityEngine;
using System.Collections;

public class EnemyDrone : Enemy {


	void Start () {
		cap = 500;
		value = 10;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
		
		God = GameObject.FindWithTag ("GameController");

	}
	
	void Update () {
		Death ();
		Debug.Log (charge);
		Aim (player);
		Fire ();

	}
}
