using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject circlePrefab;
    public float spawnInterval = 2;
    public float speed = 3;
    // Start is called before the first frame update
    public IEnumerator SpawnEnemies(int enemiesToSpawn) 
    {
        for (int i=0; i < enemiesToSpawn; i++) 
        {
            SpawnCircle();
            yield return new WaitForSeconds(spawnInterval);
        }

    }
    // Update is called once per frame
    void SpawnCircle() 
    {
        //for loop to keep spawning enemies
        GameObject circle = Instantiate(circlePrefab, transform.position, Quaternion.identity);
        // find the location of spawner to determine which direction the enemies should go
        float direction = transform.position.x > 0 ? -1: 1;
        //add rigidbody
        Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();
        //finds rigidbody on each circle and gives a speed and direction :3

        if (rb != null) {
            rb.velocity = new Vector2(direction * speed, 0);
        }
    }
}
