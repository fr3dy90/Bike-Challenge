using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    float radius;
    float maxDistance = 1000f;

    private void OnDrawGizmos()
    {
        if (transform.parent.GetComponent<RespawnSystem>().isSet)
        {
            radius = transform.parent.GetComponent<RespawnSystem>().radius;
            Vector3 newPos = transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.up * -1, out hit, maxDistance))
            {
                newPos.y = (hit.point + (Vector3.up * radius)).y;
            }
            transform.position = newPos;
        }
    }
}
