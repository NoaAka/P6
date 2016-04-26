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
		Death (damage, value, true);
		//Debug.Log (charge);
		Aim (player);
		Fire ();

		rb.velocity = -Vector3.forward;
	}
}
