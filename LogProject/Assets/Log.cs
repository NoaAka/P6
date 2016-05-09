using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {

    [Tooltip("update time in seconds")]
    public float updateInterval;


    
    private float startTime;
    private string updateTime;

    private float firstCoroutineStartTime, secondCoroutineStartTime;

    private int iterator = 0;

	
    private float secThreshold = 0.070f;//depending on update time, if a frame is too slow it might miss something..
    private float sec;
private float lessThanThreshold;
	
	
    private string systemTime;
    

    // Use this for initialization
    void Start () {
        
        
        startTime = float.Parse(System.DateTime.Now.ToString("ss.fff"));//TODO optimize, outcomment
        
        mSec = 1.0f - (float.Parse(System.DateTime.Now.ToString("ss.fff")) - sec); //in seconds

        
        //StartCoroutine(WaitForStartup()); //syncronize start at ms = 0, or close enough! 
        
    }

    // Update is called once per frame
    void Update () {
        //print(System.DateTime.Now.ToString("ss.fff"));
        //print("updateTime :"+updateTime);
        //print("first Coroutine start time "+firstCoroutineStartTime);
        //print("second Coroutine start time "+secondCoroutineStartTime);

        //print("start system time: "+startTime);

        //print("iterator : "+iterator);
        sec = float.Parse(System.DateTime.Now.ToString("ss"));
        mSec = (float.Parse(System.DateTime.Now.ToString("ss.fff")) - sec); //in Seconds, but only msec component thus .000

        if (mSec < secThreshold)
        {
            lessThanThreshold = mSec;
            systemTime = System.DateTime.Now.ToString("mm:ss.fff");
        }
        print(lessThanThreshold);
        print("system time "+systemTime);

    }

    IEnumerator WaitForStartup()
    {
        firstCoroutineStartTime = Time.time;
        yield return new WaitForSeconds(mSec);
        StartCoroutine(DataLogging());
    }
    IEnumerator DataLogging()
    {
        secondCoroutineStartTime = Time.time;
        updateTime = System.DateTime.Now.ToString("mm:ss.fff");
        iterator++;
        yield return new WaitForSeconds(updateInterval);
        StartCoroutine(DataLogging());
    }


}
