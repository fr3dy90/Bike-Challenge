using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMenu : MonoBehaviour
{
    public float speed;
    public Transform bicycle;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);   
    }
}
