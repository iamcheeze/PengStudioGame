using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    public RocketLauncherLogic launcher;
    private bool hasExploded = false;

    public Animator canim;
    public Animator canim2;

    void Start()
    {
        launcher = FindObjectOfType<RocketLauncherLogic>();
        canim = GameObject.Find("Main Camera").GetComponent<Animator>();
        canim2 = GameObject.Find("Camera Duplicate").GetComponent<Animator>();
    }

    void OnEnable()
    {
        hasExploded = false; // Reset for reuse
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasExploded && other.CompareTag("Enemy") && launcher != null)
        {
            canim.Play("CameraShake");
            canim2.Play("CameraShake");
            hasExploded = true;
            launcher.ExplodeAt(transform.position);
            gameObject.SetActive(false);
        }
    }

    public bool HasExploded()
    {
        return hasExploded;
    }
}
