using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounder : MonoBehaviour
{
    public AudioSource button;

    void OnMouseEnter()
    {
        button.Play();
    }
}
