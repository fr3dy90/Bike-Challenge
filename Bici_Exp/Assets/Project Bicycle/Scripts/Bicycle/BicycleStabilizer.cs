using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleStabilizer : MonoBehaviour
{
    Rigidbody rb;
    public float multipler;
    public Vector3 tensorRB;
    public Transform CoM;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        multipler = GlobalConfig.multiplierStabilizer;
        if(multipler == 0 )
        {
            multipler = 1;
        }
        tensorRB = rb.inertiaTensor;
        tensorRB = tensorRB * multipler;
        rb.centerOfMass = CoM.localPosition;
        rb.inertiaTensor = tensorRB;
    }

    private void FixedUpdate()
    {
       
    }
}
