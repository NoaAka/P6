using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Intensity : MonoBehaviour {

	public God god;
	private Text myText;

	void Start () {
		god = GameObject.FindWithTag ("GameController").GetComponent<God> ();
		myText = GetComponent<Text>();
		Reset();
	}
	
	public void AddIntensity (float value) {
		god.intensity += value;
		myText.text = "Intensity : "+(god.intensity).ToString();
	}

	public void Reset() {
		god.intensity = 50;
		myText.text = "Intensity : "+(god.intensity).ToString();
	}
}
