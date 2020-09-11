using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerRotation : MonoBehaviour
{
    public Transform tracker;

    private void Update()
    {
        Vector3 root = new Vector3(tracker.localRotation.x, tracker.localRotation.y, tracker.localRotation.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, root.y, transform.localEulerAngles.z);
    }
}
