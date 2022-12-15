using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Arduinore : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM3", 9600);
    public string readdata;
    public string[] data;
    public string[] dataStep;
    public Text txt;
    
    

    // string ArduinoValue;
    //public static float ArduinoParseValue = 0;

    void Start()
    {
        OpenConnection();
        //ArduinoValue = stream.ReadLine();       

        //ArduinoParseValue = float.Parse(ArduinoValue);
        //Debug.Log(ArduinoParseValue);
    }

    void Update()
    {
        //ArduinoValue = stream.ReadLine();
        //ArduinoParseValue = float.Parse(ArduinoValue);
        //Debug.Log(ArduinoParseValue);
        readdata = stream.ReadLine();
        stream.BaseStream.Flush();
        string[] data = readdata.Split(' ');
        Debug.Log(data);
        if (data[0] != " " && data[1] != " " && data[2] != " ")
        {
           dataStep[0] = data[0];
            dataStep[1] = data[1];
            dataStep[2] = data[2];

            txt.text = "Step: " + data[2];
            //dataStep[3] = data[3];
            stream.BaseStream.Flush();
        }
    }


    public void OpenConnection()
    {
        if (stream != null)
        {
            if (stream.IsOpen)
            {
                stream.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                stream.Open(); // opens the connection
                stream.ReadTimeout = 5000; // sets the timeout value before reporting error
                print("Port Opened!");
            }
        }
        else
        {
            if (stream.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }
    void OnApplicationQuit()
    {
        stream.Close();
    }
   
   
}
