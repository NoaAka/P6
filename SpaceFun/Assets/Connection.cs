using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Connection : MonoBehaviour
{


    public enum ArduinoCom {COM1,COM2,COM3,COM4,COM5,COM6}
    public ArduinoCom port;

    SerialPort stream = new SerialPort("COM3", 9600); //Set the port (com3) and the baud rate (9600, is standard on most devices)
    string GSRlog = ""; //all data from GSR
    
    private string value;

    void Start()
    {
        //stream = new SerialPort(System.Enum.GetNames(typeof(ArduinoCom))[(int)port.ToString()[3]],9600);
        stream = new SerialPort(port.ToString(), 9600);

        stream.Open(); //Open the Serial Stream.

        StartCoroutine(WaitForSerial());

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

    
    IEnumerator WaitForSerial()
    {
        yield return new WaitForSeconds(1f);
        value = stream.ReadLine(); //Read the information
        //stream.BaseStream.Flush();
        GSRlog += value + "\r\n";

        StartCoroutine(WaitForSerial());
    }


}