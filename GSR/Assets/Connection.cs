using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Connection : MonoBehaviour
{
    public int test;
    public enum TestMode { M0, M1 } //remember to set this in logfile
    public TestMode testMode;

    public enum ConnectionPort { COM1, COM2, COM3, COM4, COM5, COM6, COM7 }
    public ConnectionPort connectionPort; 

    public enum LogMode { WriteToMemory, WriteToFile}
    public LogMode logMode = LogMode.WriteToMemory;

    private string gsrValue = "";
    
    private string gsrValues = "";
    private string threshold = "";
    private string timestamps = "";

    SerialPort stream = new SerialPort("COM1", 9600); //Set the port (com3) and the baud rate (9600, is standard on most devices)
    private string value;

    private bool hasWrittenLog = false;

    private bool condition1, condition2, condition3, condition4, condition5;

    private float mSec;
    private float secThreshold = 0.070f;//depending on update time, if a frame is too slow it might miss something..
    private float sec;
    private float lessThanThreshold;
    private string systemTime;
    private float secTemp;

    void Start()
    {
        print("connectionPort :"+connectionPort.ToString());
        stream = new SerialPort(connectionPort.ToString(), 9600);
        stream.Open(); //Open the Serial Stream.
    }

    // Update is called once per frame
    void Update()
    {

        sec = float.Parse(System.DateTime.Now.ToString("ss"));
        mSec = (float.Parse(System.DateTime.Now.ToString("ss.fff")) - sec); //in Seconds, but only msec component thus .000

        //first solution
        /*
        if (mSec < secThreshold)// problem : writting two times per same timeframe due to too high secThreshold, solution : check that sec is not same as last update! 
        {
            lessThanThreshold = mSec;
          



            value = stream.ReadLine(); //Read the information, CPU will stop untill information received
            systemTime = System.DateTime.Now.ToString("mm:ss.fff");//when unity gets the data
            string[] vec2 = value.Split(',');
            if (vec2.Length > 1)
            {
                if (vec2[0] != "" && vec2[1] != "") //Check if all values are recieved
                {
                    threshold = vec2[0];
                    gsrValue = vec2[1];

                    stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
                }

                if (logMode == LogMode.WriteToMemory)
                {
                    WriteToMemory();
                }
                else if (logMode == LogMode.WriteToFile && !hasWrittenLog)
                {
                    WriteToFile();
                }

            }


        }
        print(lessThanThreshold);
        print("system time " + systemTime);
        */

        //second solution, have to hard code it!!! since using || 


        condition1 = mSec < secThreshold && Mathf.Abs(sec - secTemp) > 0.00001;//every 1 second
        //update every 200 mm 
        //if you subtract a different value from 1 and check for that.... ? first time run you subtract 0 then you subtract .2 and so on?
        //no you want to subtract 200ms first, then 400 and so on.... make float call it subtractor, that way you get a negative value 
        //so you make a loop and subtract more and more untill reset.... thus dynamic
        if (condition1 ||)//update every 200ms 
        {
            lessThanThreshold = mSec;

            secTemp = sec;


            value = stream.ReadLine(); //Read the information, CPU will stop untill information received
            systemTime = System.DateTime.Now.ToString("mm:ss.fff");//when unity gets the data
            string[] vec2 = value.Split(',');
            if (vec2.Length > 1)
            {
                if (vec2[0] != "" && vec2[1] != "") //Check if all values are recieved
                {
                    threshold = vec2[0];
                    gsrValue = vec2[1];

                    stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
                }

                if (logMode == LogMode.WriteToMemory)
                {
                    WriteToMemory();
                }
                else if (logMode == LogMode.WriteToFile && !hasWrittenLog)
                {
                    WriteToFile();
                }

            }


        }
        print(lessThanThreshold);
        print("system time " + systemTime);


    }
    void WriteToMemory()
    {
        gsrValues += gsrValue +"\r\n";
        timestamps += systemTime + "\r\n";//in minuts, seconds, and milliseconds. 
        print(System.DateTime.Now.ToString("hh:mm:ss.fff") + "threshold : " + threshold + "gsr " + gsrValue );
    }
    void WriteToFile()
    {
        System.IO.Directory.CreateDirectory("C:\\SpaceShooterLogs\\");

        System.IO.File.WriteAllText("C:\\SpaceShooterLogs\\" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt",
            "Test " + test + "\r\n"+ "testMode +"+testMode +"\r\n"+ "Time intervals" + "\r\n" + timestamps + "\r\n" + "threshold : " +threshold + "gsr" + "\r\n" + gsrValues);
        print("has written logfile");
        hasWrittenLog = true;
    }



    void OnGUI()
    {
        string newString = System.DateTime.Now.ToString("hh:mm:ss.fff") + " "+value;//TODO GSR in own stringarray
        GUI.Label(new Rect(10, 10, 300, 100), newString); //Display new values
        
        
    }
}
