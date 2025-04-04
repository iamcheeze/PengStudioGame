using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Dylan Ashraf; gnarly.lace

public class spawningSystem : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public TextMeshProUGUI waveText;

    private int waveNumber = 1;
    private int enemiesToSpawn = 3; //initial enemy count
    private bool waveActive = false;
    private const int maxEnemies = 50;
    // Update is called once per frame


    private void Update() {
        if (waveActive == false) {
            StartNewWave();
        }
    }

    void StartNewWave() {
        waveActive = true; //starts wave
        waveText.text = "Wave: " + waveNumber; //wave indicator
        enemiesToSpawn = Mathf.FloorToInt(enemiesToSpawn * 1.5f); //rounds down and multiplies enemy numbers per wave
        enemiesToSpawn = Mathf.Min(enemiesToSpawn, maxEnemies); //maxes enemies at 50, or it just gets haywire
        
        waveNumber++; //increasing wave

        if (enemySpawner != null)
        {
            StartCoroutine(enemySpawner.SpawnEnemies(enemiesToSpawn));
        }
        else
        {
            Debug.LogError("EnemySpawner not assigned in spawningSystem!");
        }

        Invoke(nameof(ResetWave), 10);
    }

    void ResetWave() {
        waveActive = false;
    }
}
