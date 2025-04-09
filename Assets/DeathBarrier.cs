using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyTracker tracker = other.GetComponent<EnemyTracker>();

            if (tracker != null && tracker.spawnerSystem != null)
            {
                tracker.spawnerSystem.UnregisterEnemy(other.gameObject);
            }

            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
}
