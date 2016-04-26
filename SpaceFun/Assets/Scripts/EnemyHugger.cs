using UnityEngine;
using System.Collections;

public class EnemyHugger : Enemy {
	
	
	new void Start () {
		base.Start ();
		cap = 100;
		value = 20;
		damage = 30f;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
	}
	
	void Update () {
		Death (damage, value, true);
		//Debug.Log (charge);
		Follow (player);
	}


}
