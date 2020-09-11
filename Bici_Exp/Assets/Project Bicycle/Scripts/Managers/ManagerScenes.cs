using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ManagerScenes
{
    public static int lastScene = 0;

    public static void LoadScenes(int index)
    {
        SceneManager.LoadScene(index);
    }
}
