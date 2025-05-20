using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoralitySystem : MonoBehaviour
{
    public float maxMorality = 100f;
    public float currentMorality;
    public float moralityDrainPerSecond = 2f;
    public float sacrificeMoralityDrain = 20f;
    public GameObject bloodEffectPrefab; // For Sacrifices
    public float bloodEffectYOffset = 0.5f;

    public static MoralitySystem Instance;

    public GameObject death;
    public Animator anim;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMorality = maxMorality;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Temporary Sacrifice NEEDS CHANGING
        {
            Sacrifice();
        }
        DrainMorality();
        CheckDeath();
    }

    // Drain morality every second
    void DrainMorality()
    {
        currentMorality -= moralityDrainPerSecond * Time.deltaTime;
    }

    void CheckDeath()
    {
        if (currentMorality <= 0f)
        {
            death.SetActive(true);
            anim.Play("PlayerDeath");
            Destroy(GameObject.Find("ThemePlayer"));
            Time.timeScale = 0f;
        }
    }

    public void LoseMorality(float amount)
    {
        currentMorality -= amount;
    }

    public void GainMorality(GameObject enemy)
    {
        EnemyCollision enemyData = enemy.GetComponent<EnemyCollision>();
        if (enemyData != null)
        {
            currentMorality = Mathf.Min(currentMorality + enemyData.moralityValueOnCure, maxMorality);
            Debug.Log("Gained morality: " + enemyData.moralityValueOnCure);
        }
    }

    public void Sacrifice()
    {


        // Get all enemies in scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0) return;

        currentMorality -= sacrificeMoralityDrain;
        Debug.Log("Morality: " + currentMorality);
        ObjectPool.instance.AddBullets();

        // Pick a random one
        GameObject target = enemies[Random.Range(0, enemies.Length)];

        // Blood Effect
        if (bloodEffectPrefab != null)
        {
            Vector3 spawnPos = target.transform.position + Vector3.up * bloodEffectYOffset;
            GameObject bloodEffect = Instantiate(bloodEffectPrefab, spawnPos, Quaternion.identity);
            
            // Destroy blood effect after it finishes
            ParticleSystem bloodParticleSystem = bloodEffect.GetComponent<ParticleSystem>();
            if (bloodParticleSystem != null)
            {
                Destroy(bloodEffect, bloodParticleSystem.main.duration); // Destroy after the duration of the particle effect
            }
        }

      // Kill the enemy without giving morality. This is because the enemy will not have the proper requirements as per EnemyCollision script
        Destroy(target);
    }
}