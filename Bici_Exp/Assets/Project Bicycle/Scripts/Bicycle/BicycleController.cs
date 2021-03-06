using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo_2
{
	public WheelCollider wheel;
	public GameObject wheelMesh;
	public bool motor;
	public bool steering;
}

public class BicycleController : MonoBehaviour
{
	public List<AxleInfo_2> axleInfos;
	public float maxMotorTorque;
	public float maxSteeringAngle;
	public float brakeTorque;
	public float decelerationForce;
    public Transform bicycleBar;
    float motor;
    public float steering;
    public float vertical;
    public float horizontal;
    public float bicycleSpeed;
    public float maxSpeed;
    public ManagerInput.Input_H input_H;

    private void Start()
    { 
        maxMotorTorque = GlobalConfig.maxMotorTorque;
        maxSteeringAngle = GlobalConfig.maxSteeringAngle;
        brakeTorque = GlobalConfig.brakeTorque;
        decelerationForce = GlobalConfig.descelerationForce;
        maxSpeed = GlobalConfig.maxSpeed;
    }

    public void ApplyLocalPositionToVisuals (AxleInfo_2 axleInfo)
	{
		Vector3 position;
		Quaternion rotation;
		axleInfo.wheel.GetWorldPose (out position, out rotation);
		axleInfo.wheelMesh.transform.position = position;
        axleInfo.wheelMesh.transform.rotation = rotation;
	}

	void FixedUpdate ()
	{
        if(!SceneController.isPlay)
        {
            return;
        }
        motor = maxMotorTorque * vertical;
        switch(input_H)
        {
            case ManagerInput.Input_H.Input:
                steering = maxSteeringAngle * horizontal;
                break;
            case ManagerInput.Input_H.Tracker:

                break;
        }
		foreach(AxleInfo_2 axleInfo in axleInfos)
		{
            if (axleInfo.steering)
            {
                Steering(axleInfo, steering);
                bicycleBar.localEulerAngles =  new Vector3(0f, steering, 0f);
            }
			if (axleInfo.motor)
			{
                Acceleration(axleInfo, motor);
			}
			if (Input.GetKey (KeyCode.Space))
			{
				Brake (axleInfo);
			} 
			ApplyLocalPositionToVisuals (axleInfo);
		}
        bicycleSpeed = Mathf.Round((GetComponent<Rigidbody>().velocity.magnitude * 3.6f) * 10f) * 0.1f;
    }

	private void Acceleration (AxleInfo_2 axleInfo, float motor)
	{
		if (motor > 0f && bicycleSpeed < maxSpeed)
		{
			axleInfo.wheel.brakeTorque = 0;
            axleInfo.wheel.motorTorque = motor;
		}
        else
		{
            motor = 0;
            vertical = 0;
            Deceleration (axleInfo);
		}
	}

	private void Deceleration (AxleInfo_2 axleInfo)
	{
		axleInfo.wheel.brakeTorque = decelerationForce;
        axleInfo.wheel.motorTorque = 0;
	}

	private void Steering (AxleInfo_2 axleInfo, float steering)
	{
		axleInfo.wheel.steerAngle = steering;
	}

	private void Brake (AxleInfo_2 axleInfo)
	{
		axleInfo.wheel.brakeTorque = brakeTorque;
	}

    public void BrakeExtreme()
    {
        axleInfos[0].wheel.brakeTorque = (brakeTorque * 1000f);
        axleInfos[1].wheel.brakeTorque = (brakeTorque * 1000f);
    }
}