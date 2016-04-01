using UnityEngine;
using System.Collections;

public class EnemyDrone : Enemy {

	public float speed = 2f;

	void Start () {
		cap = 500;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
		

	}
	
	void Update () {
		Death ();
		Debug.Log (charge);
		Aim (player);
		Fire ();

	}
}
