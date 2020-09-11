using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPongAndRotate : MonoBehaviour
{
    Vector3 pos;
    public float speed;
    public float ammplitude;
    public GameObject particle;

    public float rotateSpeed;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveObj();
        RotateObj();
    }

    private void MoveObj()
    {
        pos.y = Mathf.Sin((Time.realtimeSinceStartup + transform.GetSiblingIndex()) * speed) * ammplitude;
        transform.position += pos;
    }

    void RotateObj()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Instantiate(particle, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}