using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	public float intensity = 0f;
	public float delay = 400f;
	public float score = 0f;

	void Start () {
		
	}

	void Update () {
		delay = 400f - intensity;
		if(delay <= 40f){
			delay = 40f;
		}


	}
}
