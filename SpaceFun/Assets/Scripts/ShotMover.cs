using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {

	public float speed = 50.0f;
	public Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

}
