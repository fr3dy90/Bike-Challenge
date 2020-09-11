using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInput : MonoBehaviour
{
    BicycleController bicycle;
    public Transform trackerObject;

    public enum Input_V
    {
        Input,
        Auto,
        Arduino
    }
     public enum Input_H
    {
        Input,
        Tracker
    }
    public Input_V input_V;
    public Input_H input_H;

    private void Awake()
    {
        bicycle = GetComponent<BicycleController>();
    }

    private void Start()
    {
        input_V = (Input_V)GlobalConfig.vertical;
        input_H = (Input_H)GlobalConfig.horizontal;

        if (input_V == Input_V.Arduino)
        {
            gameObject.AddComponent<COM_Connection>();
        }
    }

    private void Update()
    {
        if (bicycle == null)
        {
            Debug.LogError("Missing Bicycle");
            return;
        }

        switch(input_V)
        {
            case Input_V.Input:
                bicycle.vertical = Input.GetAxis("Vertical");
                break;
            case Input_V.Auto:
                
                break;
            case Input_V.Arduino:
                bicycle.vertical = System.Convert.ToInt32 (GetComponent<COM_Connection>().capturedString) / GlobalConfig.maxRPM ;
                break;
        }

        switch(input_H)
        {
            case Input_H.Input:
                bicycle.horizontal = Input.GetAxis("Horizontal");
                break;
            case Input_H.Tracker:
                bicycle.horizontal = trackerObject.localRotation.y;
                break;
        }
    }

}
