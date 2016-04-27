using UnityEngine;
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
    public MusicPlayer musicPlayer;
    public enum TestMode { M0,M1} //remember to set this in logfile
    public TestMode testMode;
    [Tooltip("Test number")]
    public int test;

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
        
        if (shield <= 200)
        {
            Debug.Log("Shield: "+shield);
            audioLevel = audioLevel+audioLevel*((200-shield) / 200);
            
        }
        if(audioLevel < 1)
        {
            audioLevel = 1;
        }
        eliasLevel = (int)audioLevel / 25+1;
        if (eliasLevel > 14)
        {
            eliasLevel = 14;
        }
        if(eliasLevel < 1)
        {
            eliasLevel = 1;
        }
        //Debug.Log("Level: " + audioLevel);
        //Debug.Log("Elias: " + eliasLevel);

        //update Elias, m1 is reversed! 
        switch (testMode)
        {
            case TestMode.M0 :
                musicPlayer.setNewIntensityLevel(eliasLevel);

                break;

            case TestMode.M1 :
                musicPlayer.setNewIntensityLevel(15-eliasLevel);//reverse

                break;


        }


    }
}
