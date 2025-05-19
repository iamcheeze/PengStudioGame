using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne1 : MonoBehaviour
{
    public void LoadTwo () {
        SceneManager.LoadScene("Level2");
    }
}
