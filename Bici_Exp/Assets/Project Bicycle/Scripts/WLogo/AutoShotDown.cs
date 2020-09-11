using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShotDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShotDown", 1.3f);
    }

   void ShotDown()
    {
        gameObject.SetActive(false);
    }
}
