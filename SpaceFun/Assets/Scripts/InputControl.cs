using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour {

	public float LV, LH, RV, RH, LB, RB;

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Debug.Log ("LH: " + Input.GetAxis ("Horizontal"));
		Debug.Log ("LV: " + Input.GetAxis ("Vertical"));
		Debug.Log ("RH: " + Input.GetAxis ("PS4_RightAnalogHorizontal"));
		Debug.Log ("RV: " + Input.GetAxis ("PS4_RightAnalogVertical"));
		*/
		LH = Input.GetAxis ("Horizontal");
		LV = Input.GetAxis ("Vertical");
		RH = Input.GetAxis ("Xbox_RAnalogH");
		RV = Input.GetAxis ("Xbox_RAnalogV");
		LB = Input.GetAxis ("Xbox_LBumper");
		RB = Input.GetAxis ("Xbox_RBumper");

		if (Input.GetAxis ("Horizontal") < 0.01f && Input.GetAxis ("Horizontal") > -0.01f) {
			LH = 0.0f;
		}
		if (Input.GetAxis ("Vertical") < 0.01f && Input.GetAxis ("Vertical") > -0.01f) {
			LV = 0.0f;
		}
		if (Input.GetAxis ("Xbox_RAnalogH") < 0.01f && Input.GetAxis ("Xbox_RAnalogH") > -0.01f) {
			RH = 0.0f;
		}
		if (Input.GetAxis ("Xbox_RAnalogV") < 0.01f && Input.GetAxis ("Xbox_RAnalogV") > -0.01f) {
			RV = 0.0f;
		}
		/*
		Debug.Log ("LH: " + LH);
		Debug.Log ("LV: " + LV);
		Debug.Log ("RH: " + RH);
		Debug.Log ("RV: " + RV);
		*/
		//Debug.Log (LV);
		/*

		*/
		//R1
		if (Input.GetKey ("joystick button 4") == true) {
			//Debug.Log ("Click, ho");
			//masterBus.Volume -= 0.1f;
		}
	}
}
