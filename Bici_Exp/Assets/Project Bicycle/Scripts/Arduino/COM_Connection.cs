using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class COM_Connection : MonoBehaviour
{
    public string portName = "COM0";
    private SerialPort sp;
    [SerializeField]
    public string capturedString;
    private Thread COM_Thread;

    // Start is called before the first frame update

    private void Awake()
    {
        portName = GlobalConfig.portName;
    }
    void Start()
    {
        sp = new SerialPort(portName, 9600);
        sp.Open();
        COM_Thread = new Thread(new ThreadStart(SerialRead));
        COM_Thread.IsBackground = true;
        COM_Thread.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SerialRead()
    {
        while (true)
        {
            capturedString = sp.ReadLine();
        }
    }

    private void OnDestroy()
    {
        sp.Close();
        COM_Thread.Interrupt();
        COM_Thread.Abort();
    }

    private void OnDisable()
    {
        sp.Close();
        COM_Thread.Interrupt();
        COM_Thread.Abort();
    }

}
