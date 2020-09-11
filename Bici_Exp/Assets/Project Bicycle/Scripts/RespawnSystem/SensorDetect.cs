using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorDetect : MonoBehaviour
{
    BicycleController bicycle;
    FadeController fade;
    public Transform spawnSystem;
    int index = 0;
    bool canRespawn = true;
    public int spawn = 0;
    public float minDistance = 0;
    public float waitTime;
    float t;
    public bool manual;
    bool oneCall;
    public float distanceSpawn;
    public Transform finish;
    public float distanceFinish;

    private void Awake()
    {
        bicycle = FindObjectOfType<BicycleController>();
        fade = FindObjectOfType<FadeController>();
        StartCoroutine(Respawn(0, false));
    }

    private void Start()
    {
        oneCall = true;
    }

    private void Update()
    {
        if(!oneCall)
        {
            return;
        }
         minDistance = Vector3.Distance(transform.position, spawnSystem.GetChild(0).position);
        for(int i=0; i<spawnSystem.childCount; i++)
        {
            if(i==0)
            {
                minDistance = Vector3.Distance(transform.position, spawnSystem.GetChild(i).position);
            }
            if(Vector3.Distance (transform.position, spawnSystem.GetChild(i).position) < minDistance)
            {
                minDistance = Vector3.Distance(transform.position, spawnSystem.GetChild(i).position);
                spawn = i;
            }
        }
        if(minDistance > 10f)
        {
            StartCoroutine(fade.FadeOut());
            if (spawn > 0)
            {
               StartCoroutine (Respawn (spawn-1, true));
            }else
            {
                StartCoroutine( Respawn(0, true));
            }
            oneCall = false;
        }
        if (manual)
        {
            if (t < waitTime && bicycle.vertical > 0 && bicycle.bicycleSpeed < 1f && oneCall && SceneController.isPlay)
            {
                t += Time.deltaTime;
                if (t >= waitTime)
                {
                    t = 0;
                    oneCall = false;
                    StartCoroutine(Respawn(spawn, true));
                    
                }
            }
            else
            {
                t = 0;
            }
        }
        float dis = Vector3.Distance(transform.position, finish.position);
        if(dis < distanceFinish && SceneController.isPlay)
        {
            SceneController.CanvasEnd();
            SceneController.isPlay = false;
            StopAllCoroutines();
            Invoke("Restart", 2f);
        }
        
    }

    IEnumerator Respawn(int m_index, bool val)
    {
        float t = 0.5f;
        if (val)
        {
            yield return StartCoroutine(fade.FadeOut());
        }
        yield return new WaitForSeconds(.5f);
        while (t > 0)
        {
            yield return null;
            t -= Time.deltaTime;
            bicycle.transform.position = spawnSystem.GetChild(m_index).position + (-Vector3.up * distanceSpawn);
            bicycle.transform.eulerAngles = new Vector3(0f, spawnSystem.GetChild(m_index).eulerAngles.y, 0f);
            bicycle.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bicycle.BrakeExtreme();
        }
       
        if (val)
        {
            StartCoroutine(fade.FadeIn());
        }

        oneCall = true;
    }

    void Restart()
    {
        ManagerScenes.LoadScenes(1);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(finish.position, distanceFinish);
    }
}
