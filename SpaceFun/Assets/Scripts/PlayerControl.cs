using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private InputControl input;
	public int speed = 4;
	public Rigidbody rb;

	float moveH;
	float moveV;

	Vector3 movement;

	void Start () {
		input = GameObject.Find ("InputControl").GetComponent<InputControl> ();
	}
	
	void FixedUpdate () {
		moveH = input.LH;
		moveV = input.LH;
		movement = new Vector3(moveH,0.0f,moveV);
		rb.velocity = movement * speed;
	}
}
