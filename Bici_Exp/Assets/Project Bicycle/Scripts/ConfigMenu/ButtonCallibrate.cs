using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCallibrate : MonoBehaviour,IPointerClickHandler
{
    Calibrate calibrate;
    public bool isConfig;

    void Start()
    {
        calibrate = FindObjectOfType<Calibrate>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        calibrate.SetScene(isConfig);
        if(!isConfig)
        {
            calibrate.SavePos();
        }
    }
}
