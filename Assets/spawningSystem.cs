using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
//Dylan Ashraf; gnarly.lace

public class spawningSystem : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public TextMeshProUGUI waveText;

    public int waveNumber = 1;
    private int enemiesToSpawn = 3;
    private bool waveActive = false;
    private const int maxEnemies = 50;

    public List<GameObject> aliveEnemies = new List<GameObject>();
    public List<EnemySpawner> EnemySpawners;

    public MoralitySystem mS;

    private void Awake()
    {
        if (enemySpawner != null)
        {
            enemySpawner.spawningSystem = this;
        }
    }

    private void Update()
    {
        //starts wave if one isnt running and no enemies are alive according to list
        if (waveActive == false && aliveEnemies.Count == 0)
        {
            StartNewWave();
        }

        for (int i = 0; i < aliveEnemies.Count; i++)
        {
            if (aliveEnemies[i] == null)
            {
                aliveEnemies.RemoveAt(i);
            }
        }
    }

    void StartNewWave() {
        waveActive = true;
        waveText.text = "Wave: " + waveNumber;

        enemiesToSpawn = Mathf.FloorToInt(enemiesToSpawn * 1.5f);
        enemiesToSpawn = Mathf.Min(enemiesToSpawn, maxEnemies);
        waveNumber++;

        mS.moralityDrainPerSecond *= 1.5f;

        aliveEnemies.Clear();

        foreach (var spawner in EnemySpawners) {
            spawner.spawningSystem = this; //ensure they reference the system
            StartCoroutine(spawner.SpawnEnemies(enemiesToSpawn));
        }

        StartCoroutine(WaitForWaveToComplete());
    }

    public void RegisterEnemy(GameObject enemy) {
        aliveEnemies.Add(enemy);
    }

    public void UnregisterEnemy(GameObject enemy) {
        aliveEnemies.Remove(enemy);
    }

//waits until all enemies are gone before allowing the next wave
    IEnumerator WaitForWaveToComplete() {
        
        yield return new WaitUntil(() => aliveEnemies.Count == 0);
        waveActive = false;
    }
}
