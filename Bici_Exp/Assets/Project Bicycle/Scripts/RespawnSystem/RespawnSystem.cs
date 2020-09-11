using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public float radius;
    public float maxDistance;
    public bool isSet = false;

    private void OnDrawGizmos()
    {
        if(transform.childCount > 0)
        { 
            for(int i=0; i<transform.childCount; i++)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(transform.GetChild(i).position, radius);
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.GetChild(i).position, maxDistance);
                if (i > 0)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawLine(transform.GetChild(i - 1).position, transform.GetChild(i).position);
                    transform.GetChild(i - 1).LookAt(transform.GetChild(i));
                }
            }
        }
    }
}
