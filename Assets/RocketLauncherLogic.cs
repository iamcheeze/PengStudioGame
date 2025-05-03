using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherLogic : MonoBehaviour
{
    public KeyCode input;
    public Transform spawnpoint;
    public float rocketSpeed = 10f;
    public float shootDelay = 2f;
    public float rocketLifeTime = 5f;
    public float timeBeforeLaunch = 1f;
    public float explosionRadius = 2f;
    public int explosionDamage = 50;

    public GameObject explosionPrefab; // Explosion effect

    private float timeSinceLastShot = 0f;

    void OnEnable()
    {
        timeSinceLastShot = shootDelay - 0.5f;
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(input) && timeSinceLastShot >= shootDelay)
        {
            FireRocket(); 
            timeSinceLastShot = 0f;
        }
    }

    void FireRocket()
    {
        if (ObjectPool.instance.RocketCanShoot()) 
        {
            GameObject spawnedRocket = ObjectPool.instance.GetPooledRocket();

            if (spawnedRocket != null && spawnpoint != null)
            {
                spawnedRocket.transform.position = spawnpoint.position;
                spawnedRocket.transform.rotation = spawnpoint.rotation;
                spawnedRocket.SetActive(true);

                Rigidbody2D rb = spawnedRocket.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero; // Prevent accidental movement
                    StartCoroutine(DelayedRocketLaunch(rb)); 
                }
                else
                {
                    Debug.LogWarning("Rigidbody2D not found on rocket.");
                }

                ObjectPool.instance.UseRocket();
                StartCoroutine(DisableRocket(spawnedRocket, rocketLifeTime));
            }
            else
            {
                Debug.LogWarning("No available rockets in the pool!");
            }
        }
        else
        {
            Debug.Log("No rockets left! Sacrifice needed.");
        }
    }

    IEnumerator DelayedRocketLaunch(Rigidbody2D rb)
    {
        Vector2 launchDirection = spawnpoint.right.normalized;
        Transform rocketTransform = rb.transform;

        float shakeDuration = timeBeforeLaunch;
        float shakeIntensity = 0.05f;
        Vector3 originalPos = rocketTransform.localPosition;

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float offsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetY = Random.Range(-shakeIntensity, shakeIntensity);
            rocketTransform.localPosition = originalPos + new Vector3(offsetX, offsetY, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        rocketTransform.localPosition = originalPos;

        rb.velocity = launchDirection * rocketSpeed;
    }
    public void ExplodeAt(Vector2 position) // Exploads on Collision
    {
        // Explosion Logic
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, explosionRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy")) 
            {
                EnemyCollision enemy = hit.GetComponent<EnemyCollision>();
                if (enemy != null)
                {
                    enemy.TakeDamage(explosionDamage);
                }
            }
        }

        // 🔥 Play explosion effect
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, position, Quaternion.identity);
        }
    }
    IEnumerator DisableRocket(GameObject spawnedRocket, float rocketLifeTime)
    {
        yield return new WaitForSeconds(rocketLifeTime);

        if (spawnedRocket != null && spawnedRocket.activeSelf)
        {
            RocketBehavior behavior = spawnedRocket.GetComponent<RocketBehavior>();
            if (behavior != null && !behavior.HasExploded())
            {
                ExplodeAt(spawnedRocket.transform.position); // or just call from RocketLauncherLogic
            }

            spawnedRocket.SetActive(false);
        }
    }
}