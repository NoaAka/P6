using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour {

	public float LV, LH, RV, RH, LB, RB;
	public int inputDevice = 0;
	float delay = 0.0f;

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

		//Toggle input method
		// 0=Keyboard
		// 1=Xbox controller
		if(Input.GetKey("t") && Time.time > delay){
			delay = Time.time + 0.5f;
			inputDevice++;
			if(inputDevice==2){
				inputDevice=0;
			}
			switch(inputDevice){
			case 0:
				Debug.Log ("Keyboard is now active input device");
				break;
			case 1:
				Debug.Log ("Xbox Controller is now active input device");
				break;
			}


		}

		LH = Input.GetAxis ("Horizontal");
		LV = Input.GetAxis ("Vertical");
		if (inputDevice == 0) {
			RH = Input.GetAxis ("Keyboard_J+L");
			RV = Input.GetAxis ("Keyboard_K+I");
			//RH = Input.GetAxis ("Keyboard_J+L");
			//RH = Input.GetAxis ("Keyboard_J+L");
		}
		if (inputDevice == 1) {
			RH = Input.GetAxis ("Xbox_RAnalogH");
			RV = Input.GetAxis ("Xbox_RAnalogV");
			LB = Input.GetAxis ("Xbox_LBumper");
			RB = Input.GetAxis ("Xbox_RBumper");
		}




		if (LH < 0.01f && LH > -0.01f) {
			LH = 0.0f;
		}
		if (LV < 0.01f && LV > -0.01f) {
			LV = 0.0f;
		}
		if (RH < 0.01f && RH > -0.01f) {
			RH = 0.0f;
		}
		if (RV < 0.01f && RV > -0.01f) {
			RV = 0.0f;
		}

		Debug.Log ("LH: " + LH);
		Debug.Log ("LV: " + LV);
		Debug.Log ("RH: " + RH);
		Debug.Log ("RV: " + RV);

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
