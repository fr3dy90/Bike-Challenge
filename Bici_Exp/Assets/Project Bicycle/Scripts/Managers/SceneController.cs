using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    FadeController fadeController;
    public float m_time;
    public float durationFade;
    public Image counter;
    public Image title;
    public Sprite[] m_numbers;
    public GameObject canvasFinish;
    public static GameObject cf;

    public static bool isPlay;

    private void Awake()
    {
        fadeController = GetComponent<FadeController>();
    }

    private void Start()
    {
        cf = canvasFinish;
        cf.SetActive(false);
        isPlay = false;
        counter.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        StartCoroutine(fadeController.FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ManagerScenes.lastScene = SceneManager.GetActiveScene().buildIndex;
            ManagerScenes.LoadScenes(1);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ManagerScenes.LoadScenes(2);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CountBack());
        }
    }

    IEnumerator CountBack()
    {
        counter.gameObject.SetActive(true);
        while (m_time > 0)
        {
            yield return null;
            m_time -= Time.deltaTime;
            SetTimer((int)m_time);
        }
        counter.gameObject.SetActive(false);
        title.gameObject.SetActive(true);
        StartCoroutine(FadeTittle());
        isPlay = true;
    }

    void SetTimer(int index)
    {
        counter.gameObject.SetActive(true);
        counter.overrideSprite = m_numbers[index];
    }

    IEnumerator FadeTittle()
    {
        Color c = title.color;
        while(c.a > 0)
        {
            yield return null;
            c.a = Mathf.MoveTowards(c.a, 0, Time.deltaTime / durationFade);
            title.color = c;
        }
    }

    public static void CanvasEnd()
    {
        cf.SetActive(true);
    }
}
