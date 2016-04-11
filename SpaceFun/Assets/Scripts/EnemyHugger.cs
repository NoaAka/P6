using UnityEngine;
using System.Collections;

public class EnemyHugger : Enemy {
	
	
	new void Start () {
		base.Start ();
		cap = 100;
		value = 20;
		damage = 30;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
	}
	
	void Update () {
		Death (value);
		//Debug.Log (charge);
		Follow (player);
	}

	void OnCollisionEnter(Collider hit){
		if (hit.tag == "PlayerShip" || hit.tag == "PlayerShield") {
			//Debug.Log ("Testing");
			if (hit.GetComponent<PlayerControl> ().shieldPower < 0) {
				Debug.Log ("Player Lost!");
			} else {
				hit.GetComponent<PlayerControl> ().shieldPower -= damage;
			}
		}
	}
}
