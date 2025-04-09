using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public spawningSystem spawnerSystem;

    // Update is called once per frame

    private void OnDestroy() {
        spawnerSystem.UnregisterEnemy(gameObject);
    }
}
