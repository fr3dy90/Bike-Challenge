using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExit : MonoBehaviour, IPointerClickHandler
{
    public int i_indexLoad;
    public void OnPointerClick(PointerEventData eventData)
    {
       if(ManagerScenes.lastScene == 0)
        {
            ManagerScenes.LoadScenes(i_indexLoad);
        }
       else
        {
            ManagerScenes.LoadScenes(ManagerScenes.lastScene);
        }
    }
}
