using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            spawningSystem system = FindObjectOfType<spawningSystem>(); //find the system
            system.UnregisterEnemy(other.gameObject); //remove from list

            Destroy(other.gameObject);
        }
    }
}