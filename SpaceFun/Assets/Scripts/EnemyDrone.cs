using UnityEngine;
using System.Collections;

public class EnemyDrone : Enemy {


	new void Start () {
		base.Start ();
		cap = 500;
		value = 10;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;

	}
	
	void Update () {
		Death ();
		//Debug.Log (charge);
		Aim (player);
		Fire ();

	}
}
