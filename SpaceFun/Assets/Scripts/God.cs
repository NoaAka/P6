﻿using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	public float intensity = 50f;
	public float revIntensity = 0f;
	public float delay = 400f;
	public float score = 0f;
	public float intMultiplier = 0f;
	public float revIntMultiplier = 0f;
    public float shield = 0f;
    public float audioLevel = 0f;
    public int eliasLevel = 1; 

	void Start () {

	}

	void Update () {
        revIntensity = 400f - intensity;
		delay = revIntensity;
		if(delay <= 50f){
			delay = 50f;
		}
		//Debug.Log (delay);
		intMultiplier = intensity / 400f;
		//Debug.Log ("Intensity: "+intMultiplier);
		revIntMultiplier = revIntensity / 400f;
        //Debug.Log ("RevIntensity: "+revIntMultiplier);
        audioLevel = (int)intensity - 50;
        if(shield <= 200)
        {
            Debug.Log("Shield: "+shield);
            audioLevel = audioLevel+audioLevel*((200-shield) / 200);
        }
        eliasLevel = (int)audioLevel / 25+1;
        if (eliasLevel > 14)
        {
            eliasLevel = 14;
        }
        Debug.Log("Level: " + audioLevel);
        Debug.Log("Elias: " + eliasLevel);
    }
}
