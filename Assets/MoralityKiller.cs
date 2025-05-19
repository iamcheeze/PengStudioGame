using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoralityKiller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MoralitySystem>().currentMorality = 0;
        }
    }
}
