using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ManagerConfig config;
    public RectTransform container;
    public bool isOpen;
    public Text myText;

    public enum Axis
    {
        Vertical,
        Horizontal
    }
    public Axis axis;

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }

    public void SetValue(int value)
    {
        myText.text = container.GetChild(value).GetComponentInChildren<Text>().text;
        switch(axis)
        {
            case Axis.Vertical:
                config.vertical = value;
                break;

            case Axis.Horizontal:
                config.horizontal = value;
                break;
        }
    }
}
