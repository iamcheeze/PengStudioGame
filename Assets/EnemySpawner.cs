using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject circlePrefab;
    public float spawnInterval = 2;
    public float speed = 3;

    public spawningSystem spawningSystem; //reference to spawningSystem

    public IEnumerator SpawnEnemies(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn; i++) 
        {
            GameObject circle = SpawnCircle();
            spawningSystem?.RegisterEnemy(circle); //register the spawned enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    GameObject SpawnCircle() 
    {
        GameObject circle = Instantiate(circlePrefab, transform.position, Quaternion.identity);
        float direction = transform.position.x > 0 ? -1 : 1;

        Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();
        if (rb != null) {
            rb.velocity = new Vector2(direction * speed, 0);
        }

        return circle; //return the spawned enemy
    }
}
