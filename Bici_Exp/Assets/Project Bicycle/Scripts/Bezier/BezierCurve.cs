using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    float t;
    public int res;
    public GameObject[] curvePoint;
    public GameObject pref;

    private void Awake()
    {
        curvePoint = new GameObject[res];
        for(int i=0; i<curvePoint.Length; i++)
        {
            GameObject go = Instantiate(pref, this.transform);
            go.name = "Point_" + i;
            curvePoint[i] = go;
        }

        DrawCurve();
    }

    private void Update()
    {
        DrawCurve();
    }

    void DrawCurve()
    {
        for(int i=1; i<curvePoint.Length +1; i++)
        {
            t = i / (float)res;
            curvePoint[i-1].transform.position = point(t, p0, p1, p2);
        }
    }

    Vector3 point(float t, Transform p0, Transform p1, Transform p2)
    {
        Vector3 r_pointr = (((1 - t) * (1 - t)) * p0.position) + ((2 * (1 - t)) * t * p1.position) + ((t * t) * p2.position);
        return r_pointr;
    }

    //B(t) = uu P0 + 2(u) t P1 + tt P2
}
