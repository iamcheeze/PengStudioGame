using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisabler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletType"))
        {
            RocketBehavior rocket = other.GetComponent<RocketBehavior>();
            if (rocket != null)
            {
                rocket.launcher.ExplodeAt(other.transform.position);
            }

            other.gameObject.SetActive(false);
        }
    }
}