using UnityEngine;
using System.Collections;

public class EnemyBolt : Enemy {


	new void Start () {
		base.Start ();
		cap = 20;
		value = 0;
		speed = 10f;
		damage = 10f;
		rb = GetComponent<Rigidbody> ();
		
		rb.velocity = transform.forward * speed;
	}
	
	void Update () {
		Death (value, value, 1f);
	}
}
