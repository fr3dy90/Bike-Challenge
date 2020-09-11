using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSettings : MonoBehaviour, IPointerClickHandler
{
    ManagerConfig config;
    public enum Action
    {
        Save,
        Load,
        Default
    }
    public Action action;

    private void Awake()
    {
        config = FindObjectOfType<ManagerConfig>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch(action)
        {
            case Action.Save:
                config.SaveParameters();
                break;
            case Action.Load:
                config.LoadParameters();
                break;
            case Action.Default:
                config.DefaultConfig();
                break;
        }
    }
}
