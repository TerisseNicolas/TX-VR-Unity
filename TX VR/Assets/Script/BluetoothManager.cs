using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

using System.IO.Ports;

public class BluetoothManager : MonoBehaviour
{
    //public static SerialPort sp = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
    public static SerialPort sp = new SerialPort("RFCOMM", 9600);

    void Start()
    {
        //OpenConnection();
    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();  // opens the connection
                sp.ReadTimeout = 16;  // sets the timeout value before reporting error
                Debug.Log("Port Opened!");
            }
        }
        else
        {
            if (sp.IsOpen)
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
        sp.Close();
    }

    public static void send(VibrationZoneType zone, VibrationType vibrationType, int optionnalDuration = 0)
    {
        //conventions: vibrationZone@vibrationType@duration (duration present only if vibrationType = 'limited'
        string message = zone.ToString() + "@" + vibrationType.ToString() + "@";
        if (vibrationType == VibrationType.limited)
        {
            message += optionnalDuration.ToString();
        }
        sp.Write(message);
    }
}
