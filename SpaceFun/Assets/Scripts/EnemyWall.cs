using UnityEngine;
using System.Collections;

public class EnemyWall : Enemy {

	
	new void Start () {
		base.Start ();
		cap = 500;
		value = 20;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;

		
	}
	
	void Update () {
		Death (value);
		//Debug.Log (charge);

		rb.velocity = -transform.forward;
	}
}
