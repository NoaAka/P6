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

	void OnCollisionEnter(Collision hit){
		Debug.Log (hit.gameObject.tag);
		if (hit.gameObject.tag == "PlayerShip" || hit.gameObject.tag == "PlayerShield" || hit.gameObject.tag == "Player") {
			Debug.Log ("Testing");
			if (hit.gameObject.GetComponent<PlayerControl> ().shieldPower < 0) {
				Debug.Log ("Player Lost!");
				charge = cap+1;
				Death (0);
			} else {
				hit.gameObject.GetComponent<PlayerControl> ().shieldPower -= damage;
				charge = cap+1;
				Death (0);
				Debug.Log ("Damage to " + hit.gameObject.name);
			}
		}
	}
}
