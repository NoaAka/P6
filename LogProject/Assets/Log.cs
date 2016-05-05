using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {

    [Tooltip("update time in milliseconds")]
    public int updateInterval;


    private float startDelay;
    private string nowTime, startSecString;
    private string updateTime;

    // Use this for initialization
    void Start () {
        float startSec = float.Parse(System.DateTime.Now.ToString("ss"));
        startSecString = ("sec :" + startSec);
        nowTime = ("Now time : "+System.DateTime.Now.ToString("ss.fff"));//TODO optimize, outcomment
        
        startDelay = 1.0f - (float.Parse(System.DateTime.Now.ToString("ss.fff")) - startSec);

        StartCoroutine(WaitForStartup()); //syncronize start at ms = 0, or close enough! 
        
    }

    // Update is called once per frame
    void Update () {
        //print(System.DateTime.Now.ToString("ss.fff"));



        //startDelay = float.Parse(System.DateTime.Now.ToString("ss.fff"));
        print("updateTime :"+updateTime);

       
    }

    IEnumerator WaitForStartup()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(DataLogging());
    }
    IEnumerator DataLogging()
    {

        updateTime = System.DateTime.Now.ToString("mm:ss.fff");


        yield return new WaitForSeconds(updateInterval);
        StartCoroutine(DataLogging());


    }


}
