using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	public float intensity = 50f;
	public float revIntensity = 0f;
	public float delay = 400f;
	public float score = 0f;
	public float intMultiplier = 0f;
	public float revIntMultiplier = 0f;

	void Start () {
		
	}

	void Update () {
		revIntensity = 400f - intensity;
		delay = revIntensity;
		if(delay <= 50f){
			delay = 50f;
		}
		Debug.Log (delay);
		intMultiplier = intensity / 400f;
		//Debug.Log ("Intensity: "+intMultiplier);
		revIntMultiplier = revIntensity / 400f;
		//Debug.Log ("RevIntensity: "+revIntMultiplier);

	}
}
