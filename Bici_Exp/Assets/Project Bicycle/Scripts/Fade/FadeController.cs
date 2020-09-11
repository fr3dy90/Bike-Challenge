using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image img_Fade;
    public float f_time;
    public bool isReady;
    public bool Set = false;

    private void Start()
    {
        img_Fade.gameObject.SetActive(true);
    }

    public IEnumerator FadeIn()
    {
        float start = 1;
        Color c = img_Fade.color;
        c.a = start;
        while (c.a > 0)
        {
            yield return null;
            c.a = Mathf.MoveTowards(c.a, 0, Time.deltaTime / f_time);
            img_Fade.color = c;
        }
    }

    public IEnumerator FadeOut()
    {
        Set = false;
        isReady = false;
        float start = 0;
        Color c = img_Fade.color;
        c.a = start;
        while(c.a < 1)
        {
            yield return null;
            c.a = Mathf.MoveTowards(c.a, 1, Time.deltaTime / f_time);
            img_Fade.color = c;
        }
    }
}
