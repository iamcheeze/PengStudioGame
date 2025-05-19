using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour
{
    public void LoadOne () {
        SceneManager.LoadScene("Level1");
    }
}
