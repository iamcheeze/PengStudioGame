using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemePlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
