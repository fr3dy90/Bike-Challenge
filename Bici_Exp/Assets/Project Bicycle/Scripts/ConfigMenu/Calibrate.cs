using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrate : MonoBehaviour
{
    public ManagerConfig config;
    public Transform myCamera;
    public GameObject menu;
    public GameObject panel;
    public bool isSetCamera;
    public float speed;
    public Vector3 pos;

    void Start()
    {
        SetScene(false);
    }

    private void Update()
    {
        if(isSetCamera)
        {
            if(Input.GetKey(KeyCode.W))
            {
                pos.z += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z -= speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.A))
            {
                pos.x -= speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.D))
            {
                pos.x += speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.Q))
            {
                pos.y += speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.E))
            {
                pos.y -= speed * Time.deltaTime;
            }
            SetPos();
        }
    }

    public void SetScene(bool isSet)
    {
        isSetCamera = isSet;
        menu.SetActive(!isSet);
        panel.SetActive(isSet);
    }

    public void SavePos()
    {
        config.cameraPos = pos;
    }

    public void LoadPos()
    {
        pos = config.cameraPos;
        SetPos();
    }

    void SetPos()
    {
        myCamera.transform.localPosition = pos;
    }
}
