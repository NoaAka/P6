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

    void Start()
    {
        print("connectionPort :"+connectionPort.ToString());
        stream = new SerialPort(connectionPort.ToString(), 9600);
        stream.Open(); //Open the Serial Stream.
    }

    // Update is called once per frame
    void Update()
    {
        value = stream.ReadLine(); //Read the information
        string[] vec2 = value.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
        if (vec2.Length > 1)
        {
            if (vec2[0] != "" && vec2[1] != "") //Check if all values are recieved
            {
                threshold = vec2[0];
                gsrValue = vec2[1];

                stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
            }

            if(logMode == LogMode.WriteToMemory)
            {
                WriteToMemory();
            }
            else if( logMode == LogMode.WriteToFile && !hasWrittenLog)
            {
                WriteToFile();
            }
 
        }
        
    }
    void WriteToMemory()
    {
        gsrValues += gsrValue +"\r\n";
        timestamps += System.DateTime.Now.ToString("hh:mm:ss.fff") +"\r\n";
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
