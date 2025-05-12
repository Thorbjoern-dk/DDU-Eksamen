using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class ArdRead : MonoBehaviour
{
    private SerialPort stream;
    private Thread readThread;
    private string latestData = "000";
    private bool running;

    void Start()
    {
        stream = new SerialPort("COM14", 9600);
        stream.ReadTimeout = 1000;
        stream.Open();

        running = true;
        readThread = new Thread(ReadFromArduino);
        readThread.Start();
    }

    private void ReadFromArduino()
    {
        while (running)
        {
            try
            {
                string line = stream.ReadLine().Trim();
                lock (this)
                {
                    latestData = line;
                }
            }
            catch (System.Exception) { }
        }
    }

    public string GetLatestData()
    {
        lock (this)
        {
            return latestData;
        }
    }

    void OnApplicationQuit()
    {
        running = false;
        if (readThread != null && readThread.IsAlive)
            readThread.Join();
        if (stream != null && stream.IsOpen)
            stream.Close();
    }
}
