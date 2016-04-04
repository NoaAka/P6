using UnityEngine;
using System.Collections;

public class EnemyWall : Enemy {
	
	public float speed = 2f;
	
	void Start () {
		cap = 500;
		value = 20;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
		
		God = GameObject.FindWithTag ("GameController");
		
	}
	
	void Update () {
		Death ();
		Debug.Log (charge);

	}
}
