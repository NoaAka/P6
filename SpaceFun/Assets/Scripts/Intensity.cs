using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Intensity : MonoBehaviour {

	public int intensity;
	private Text myText;

	void Start () {
		myText = GetComponent<Text>();
		Reset();
	}
	
	public void AddIntensity (int value){
		intensity += value;
		myText.text = "Intensity : "+(intensity-600).ToString();

	}

	public void Reset()
	{
		intensity = 600;
		myText.text = "Intensity : "+(intensity-600).ToString();
	}
}
