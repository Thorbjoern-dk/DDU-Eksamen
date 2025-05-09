using UnityEngine;
using System.IO.Ports;
public class ArdRead : MonoBehaviour
{
    [SerializeField] string port = "COM14";
    SerialPort stream;

    public char[] slots;
    public string serial_input;

    void Start()
    {
        stream = new(port, 9600)
        {
            WriteTimeout = 500,
            ReadTimeout = 1000,
            DtrEnable = true,
            RtsEnable = true
        };
        stream.Open();
    }

    void Update()
    {
        try
        {
            serial_input = stream.ReadLine();
            slots = serial_input.ToCharArray();
        }
        catch (System.TimeoutException)
        {
            // Debug.Log("Serial input timeout");
        }
    }
    void OnDisable()
    {
        stream.Close();
    }
}