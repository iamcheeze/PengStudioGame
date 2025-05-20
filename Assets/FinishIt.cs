using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishIt : MonoBehaviour
{
    public string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneName);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
