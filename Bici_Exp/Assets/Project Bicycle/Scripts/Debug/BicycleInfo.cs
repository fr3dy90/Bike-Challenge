using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BicycleInfo : MonoBehaviour
{
    BicycleController bicycle;
    COM_Connection arduinoCom;
    ManagerInput managerinput;

    bool isDebug;
    public Text bicycleSpeed;
    public Text input_V;
    public Text arduinoPort;
    public Text arduinoString;
    public GameObject canvasDebug;
    bool isArduino;

    private void Start()
    {
        managerinput = GetComponent<ManagerInput>();
        bicycle = GetComponent<BicycleController>();
        isDebug = true;
        ShowDebug(isDebug);

        if (managerinput.input_V == ManagerInput.Input_V.Arduino)
        {
            isArduino = true;
            arduinoCom = FindObjectOfType<COM_Connection>();
            arduinoPort.transform.parent.gameObject.SetActive(true);
            arduinoString.transform.parent.gameObject.SetActive(true);
            arduinoPort.text = arduinoCom.portName;
        }
        else
        {
            arduinoPort.transform.parent.gameObject.SetActive(false);
            arduinoString.transform.parent.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        bicycleSpeed.text = bicycle.bicycleSpeed.ToString();
        input_V.text = bicycle.vertical.ToString();
        if (isArduino)
        {
            arduinoString.text = arduinoCom.capturedString;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            isDebug = !isDebug;
            ShowDebug(isDebug);
        }
    }

    void ShowDebug(bool val)
    {
        canvasDebug.gameObject.SetActive(val);
    }
}
