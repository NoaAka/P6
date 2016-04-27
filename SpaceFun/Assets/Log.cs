using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour
{
    public God god;

    

    [Tooltip("Update time in seconds")]
    [Range(0.0f, 2.0f)]
    public float updateInterval;

    public enum LogChoices { writeToMemory, writeToFile }
    public LogChoices log = LogChoices.writeToMemory;
    private bool hasWrittenLogToFile = false;

    private string intensityLog = "";
    private string gsrData = "";//temp data 
    private string gsrLog = "";
    private float tempTime = 0.0f;
    

    private string timeLog = "";



    // Use this for initialization
    void Start()
    {
        tempTime = Time.time + updateInterval;

    }

    // Update is called once per frame
    void Update()
    {

        switch (log)
        {

            case LogChoices.writeToMemory://TODO make as coroutine
                if (Time.time >= tempTime)
                {
                    tempTime += updateInterval;

                    intensityLog += god.eliasLevel + "\r\n";
                    //gsrLog += Random.Range(0, 20) + "\r\n";
                    timeLog += Time.time + "\r\n";
                    gsrLog += gsrData + "\r\n";
                    print(gsrData);
                }
                break;

            case LogChoices.writeToFile:

                if (!hasWrittenLogToFile)
                {

                    WriteLogToFile();

                }
                break;

        }

    }

    private void WriteLogToFile()
    {
        System.IO.Directory.CreateDirectory("C:\\SpaceShooterLogs\\");

        System.IO.File.WriteAllText("C:\\SpaceShooterLogs\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt",
            "Test " + god.test + "\r\n" + "Test mode " + god.testMode.ToString() + "\r\n" + "Time intervals" + "\r\n" + timeLog + "\r\n" + "intensity " + "\r\n" + intensityLog + "\r\n" + "gsr" + "\r\n" + gsrLog);
        hasWrittenLogToFile = true;
        print("has written logfile");
    }


    public void GSRUpdate(string data)
    {
        gsrData = data;
        
    }
}
