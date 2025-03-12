using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Dylan Ashraf; gnarly.lace

public class spawningSystem : MonoBehaviour
{
    public GameObject circlePrefab;
    public float spawnInterval = 2;
    public float speed = 3;
    private float timer = 0;
    // Update is called once per frame
    private void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnInterval) {
            SpawnCircle();
            timer = 0;
        }
    }

    // spawning circle script
    void SpawnCircle() {
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
