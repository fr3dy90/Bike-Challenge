using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption : MonoBehaviour
{
    public float over;
    public int index;

    private void OnMouseEnter()
    {
        transform.localScale = transform.localScale * over;
    }

    private void OnMouseExit()
    {
        transform.localScale = transform.localScale / over;
    }

    private void OnMouseDown()
    {
        ManagerScenes.LoadScenes(index);
    }
}
