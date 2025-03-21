using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Dylan Ashraf; gnarly.lace

public class spawningSystem : MonoBehaviour
{
    public GameObject circlePrefab;
    public TextMeshProUGUI waveText;

    public float spawnInterval = 2;
    public float speed = 3;
    private float timer = 0;

    private int waveNumber = 1;
    private int enemiesToSpawn = 3; //initial enemy count
    private int enemiesSpawned = 0;
    private bool waveActive = false;
    private const int maxEnemies = 50;
    // Update is called once per frame
    private void Update() {
        if (waveActive == false) {
            StartNewWave();
        }

        timer += Time.deltaTime;
        if (timer >= spawnInterval && enemiesSpawned < enemiesToSpawn) {
            SpawnCircle();
            timer = 0;
        }
    }

    void StartNewWave() {
        waveActive = true; //starts wave
        waveText.text = "Wave: " + waveNumber; //wave indicator
        enemiesSpawned = 0; //enemies spawned so far
        enemiesToSpawn = Mathf.FloorToInt(enemiesToSpawn * 1.5f); //rounds down and multiplies enemy numbers per wave
        enemiesToSpawn = Mathf.Min(enemiesToSpawn, maxEnemies); //maxes enemies at 50, or it just gets haywire
        
        waveNumber++; //increasing wave

        StartCoroutine(SpawnEnemiesOneByOne());
    }

    IEnumerator SpawnEnemiesOneByOne() {
        for (int i=0; i < enemiesToSpawn; i++) {
            SpawnCircle();
            yield return new WaitForSeconds(spawnInterval);
        }

        Invoke(nameof(ResetWave), 3);
    }

    void ResetWave() {
        waveActive = false;
    }

    // spawning circle script
    void SpawnCircle() {
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

        enemiesSpawned++;
    }
}
