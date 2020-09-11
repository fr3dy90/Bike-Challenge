using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerConfig : MonoBehaviour
{
    [Header("External Componontes")]
    public DropDownMenu verticalDrop;
    public DropDownMenu horizontalDrop;
    Calibrate calibrate;

    [Header("Bicycle Config")]
    public InputField maxMotorTorque;
    public InputField maxSteeringAngle;
    public InputField brakeTorque;
    public InputField descelerationForce;
    public InputField maxSpeed;

    [Header("Bicycle Stabilizer")]
    public InputField multiplierStabilizer;

    [Header("Camera Config")]
    public InputField smoothing;

    [Header("Arduino Config")]
    public InputField portName;
    public InputField maxRPM;

    [Header("Calibrate Camera")]
    public Vector3 cameraPos;

    [Header("Input Config")]
    public int vertical;
    public int horizontal;

    [Header ("Float Values")]
    public float f_maxMotorTorque;
    public float f_maxSteeringAngle;
    public float f_brakeTorque;
    public float f_descelerationForce;
    public float f_maxSpeed;
    public float f_multiplierStabilizer;
    public float f_smoothing;
    public string s_PortName;
    public float f_maxRPM;

    private void Awake()
    {
        calibrate = FindObjectOfType<Calibrate>();
        if (PlayerPrefs.HasKey("MaxMotorTorque"))
        {
            LoadParameters();
        }
        else
        {
            DefaultConfig();
        }
    }

    public void SaveParameters()
    {
        f_maxMotorTorque = float.Parse(maxMotorTorque.text);
        f_maxSteeringAngle = float.Parse(maxSteeringAngle.text);
        f_brakeTorque = float.Parse(brakeTorque.text);
        f_descelerationForce = float.Parse(descelerationForce.text);
        f_maxSpeed = float.Parse(maxSpeed.text);
        f_multiplierStabilizer = float.Parse(multiplierStabilizer.text);
        f_smoothing = float.Parse(smoothing.text);
        s_PortName = portName.text;
        f_maxRPM = float.Parse(maxRPM.text);

        PlayerPrefs.SetFloat("MaxMotorTorque", f_maxMotorTorque);
        PlayerPrefs.SetFloat("MaxSteeringAngle", f_maxSteeringAngle);
        PlayerPrefs.SetFloat("BrakeTorque", f_brakeTorque);
        PlayerPrefs.SetFloat("DescelerationForce", f_descelerationForce);
        PlayerPrefs.SetFloat("MaxSpeed", f_maxSpeed);
        PlayerPrefs.SetFloat("multiplierStabilizer", f_multiplierStabilizer);
        PlayerPrefs.SetFloat("Smoothing", f_smoothing);
        PlayerPrefs.SetString("PortName", s_PortName);
        PlayerPrefs.SetFloat("MaxRPM", f_maxRPM);
        PlayerPrefs.SetFloat("CamPos.x", cameraPos.x);
        PlayerPrefs.SetFloat("CamPos.Y", cameraPos.y);
        PlayerPrefs.SetFloat("CamPos.Z", cameraPos.z);
        PlayerPrefs.SetInt("Vertical", vertical);
        PlayerPrefs.SetInt("Horizontal", horizontal);

        SetGlobal();
    }

    public void LoadParameters()
    {
        f_maxMotorTorque = PlayerPrefs.GetFloat("MaxMotorTorque");
        f_maxSteeringAngle = PlayerPrefs.GetFloat("MaxSteeringAngle");
        f_brakeTorque = PlayerPrefs.GetFloat("BrakeTorque");
        f_descelerationForce = PlayerPrefs.GetFloat("DescelerationForce");
        f_maxSpeed = PlayerPrefs.GetFloat("MaxSpeed");
        f_multiplierStabilizer = PlayerPrefs.GetFloat("multiplierStabilizer");
        f_smoothing = PlayerPrefs.GetFloat("Smoothing");
        s_PortName = PlayerPrefs.GetString("PortName");
        f_maxRPM = PlayerPrefs.GetFloat("MaxRPM");
        cameraPos.x = PlayerPrefs.GetFloat("CamPos.x");
        cameraPos.y = PlayerPrefs.GetFloat("CamPos.Y");
        cameraPos.z = PlayerPrefs.GetFloat("CamPos.Z");
        vertical = PlayerPrefs.GetInt("Vertical");
        horizontal = PlayerPrefs.GetInt("Horizontal");

        maxMotorTorque.text = f_maxMotorTorque.ToString();
        maxSteeringAngle.text = f_maxSteeringAngle.ToString();
        brakeTorque.text = f_brakeTorque.ToString();
        descelerationForce.text = f_descelerationForce.ToString();
        maxSpeed.text = f_maxSpeed.ToString();
        multiplierStabilizer.text = f_multiplierStabilizer.ToString();
        smoothing.text = f_smoothing.ToString();
        portName.text = s_PortName;
        maxRPM .text= f_maxRPM.ToString();
        
        SetGlobal();
    }

    public void DefaultConfig()
    {
        f_maxMotorTorque = 150f;
        f_maxSteeringAngle = 30f;
        f_brakeTorque = 200f;
        f_descelerationForce = 100f;
        f_maxSpeed = 20f;
        f_multiplierStabilizer = 2.6f;
        f_smoothing = 20f;
        s_PortName = "COM 0";
        f_maxRPM = 3000f;
        cameraPos = Vector3.zero;
        horizontal = 0;
        vertical = 0;

        maxMotorTorque.text = f_maxMotorTorque.ToString();
        maxSteeringAngle.text = f_maxSteeringAngle.ToString();
        brakeTorque.text = f_brakeTorque.ToString();
        descelerationForce.text = f_descelerationForce.ToString();
        maxSpeed.text = f_maxSpeed.ToString();
        multiplierStabilizer.text = f_multiplierStabilizer.ToString();
        smoothing.text = f_smoothing.ToString();
        portName.text = s_PortName;
        maxRPM.text = f_maxRPM.ToString();

        SetGlobal();
    }

    public void SetGlobal()
    {
        GlobalConfig.maxMotorTorque = f_maxMotorTorque;
        GlobalConfig.maxSteeringAngle = f_maxSteeringAngle;
        GlobalConfig.brakeTorque = f_brakeTorque;
        GlobalConfig.descelerationForce = f_descelerationForce;
        GlobalConfig.maxSpeed = f_maxSpeed;
        GlobalConfig.multiplierStabilizer = f_multiplierStabilizer;
        GlobalConfig.smoothing = f_smoothing;
        GlobalConfig.portName = s_PortName;
        GlobalConfig.maxRPM = f_maxRPM;
        GlobalConfig.cameraPos = cameraPos;
        GlobalConfig.vertical = vertical;
        GlobalConfig.horizontal = horizontal;

        calibrate.pos = cameraPos;
        calibrate.LoadPos();

        verticalDrop.SetValue(vertical);
        horizontalDrop.SetValue(horizontal);
    }
}
