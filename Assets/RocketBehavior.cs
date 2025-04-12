using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    public RocketLauncherLogic launcher;
    private bool hasExploded = false;

    void Start()
    {
        launcher = FindObjectOfType<RocketLauncherLogic>();
    }

    void OnEnable()
    {
        hasExploded = false; // Reset for reuse
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasExploded && other.CompareTag("Enemy") && launcher != null)
        {
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
