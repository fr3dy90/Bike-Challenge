using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropDownItem : MonoBehaviour, IPointerClickHandler
{
    public DropDownMenu dropMenu;
    public int value;

    public void OnPointerClick(PointerEventData eventData)
    {
        dropMenu.SetValue(value);
        dropMenu.isOpen = false;
    }
}
