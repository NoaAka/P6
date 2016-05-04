using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Connection : MonoBehaviour
{
    public Log log;

    public enum ArduinoCom { COM1, COM2, COM3, COM4, COM5, COM6 }
    public ArduinoCom po    rt;

    [Tooltip("1 sec recommended for GSR, .1 sec for RTII")]
    public float updateTime;

    public enum OperationMode { GSR,RTII}
    public OperationMode operationMode;

    public string tilt;
    public float rotation;

    SerialPort stream = new SerialPort("COM3", 9600); //Set the port (com3) and the baud rate (9600, is standard on most devices)
    string GSRlog = ""; //all data from GSR
    
    private string value;

    void Start()
    {
        //stream = new SerialPort(System.Enum.GetNames(typeof(ArduinoCom))[(int)port.ToString()[3]],9600);
        stream = new SerialPort(port.ToString(), 9600);

        stream.Open(); //Open the Serial Stream.

        StartCoroutine(SerialUpdate());

    }

    // Update is called once per frame
    void Update()
    {


        //print(Time.time + " GSRlog : "+GSRlog +"\r\n");

        /*
        string[] vec3 = value.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
        if (vec3[0] != "" && vec3[1] != "" && vec3[2] != "") //Check if all values are recieved
        {
            stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
        }
        */

        


    }

    
    IEnumerator SerialUpdate()
    {


        switch (operationMode)
        {
            case OperationMode.GSR:
                yield return new WaitForSeconds(updateTime);
                value = stream.ReadLine(); //Read the information for GSR

                                           //stream.BaseStream.Flush(); //optional
                log.GSRUpdate(value);
                break;

            case OperationMode.RTII:
                yield return new WaitForSeconds(updateTime);
                value = stream.ReadLine(); //Read the information for GSR
                //stream.BaseStream.Flush(); //optional
                string[] vec2 = value.Split(',');
                print("Tilt : "+ vec2[0]+"Rotation : "+vec2[1]);
                tilt = vec2[0];
                rotation = float.Parse(vec2[1]);
                break;

        }
        

       


        StartCoroutine(SerialUpdate());
    }


}