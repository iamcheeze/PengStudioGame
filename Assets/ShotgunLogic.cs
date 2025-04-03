using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunLogic : MonoBehaviour
{
    public KeyCode input;
    public List<Transform> firepoints;
    public float bulletSpeed = 10f;
    public float shootDelay = 0.5f;
    public float bulletLifeTime = 5f;

    private float timeSinceLastShot = 0f;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        // Delay and shotgun firing on key press
        if (Input.GetKeyDown(input) && timeSinceLastShot >= shootDelay)
        {
            FireShotgun();
            timeSinceLastShot = 0f; // Time reset
        }
    } 
void FireShotgun()
{
    if (firepoints.Count > 0 && ObjectPool.instance.ShotgunCanShoot())
    {
        foreach (Transform firepoint in firepoints)
        {
            GameObject spawnedBullet = ObjectPool.instance.GetPooledShotgunBullet();

            if (spawnedBullet != null)
            {
                spawnedBullet.transform.position = firepoint.position;
                spawnedBullet.transform.rotation = firepoint.rotation;
                spawnedBullet.SetActive(true);

                Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
    
                if (rb != null)
                {
                    rb.velocity = firepoint.right * bulletSpeed; // Fire in the firepoint's direction
                }
                else
                {
                    Debug.LogWarning("Rigidbody2D not found on bullet.");
                }

                // Start coroutine
                StartCoroutine(DisableBullet(spawnedBullet, bulletLifeTime));
            }
            else
            {
                Debug.LogWarning("No pooled shotgun bullet available.");
            }
        }
        ObjectPool.instance.UseShotgunBullet();
        Debug.Log("Shotgun fired from " + firepoints.Count + " firepoints.");
    }
        else
        {
            Debug.Log("No shotgun bullets left! Sacrifice needed.");
        }
        IEnumerator DisableBullet(GameObject bullet, float bulletLifeTime)
        {
        yield return new WaitForSeconds(bulletLifeTime);
        if (bullet != null)
        {
            bullet.SetActive(false); 
        }
    }
}
    /*  void FireShotgun()
      {
          if (bullet != null && firepoints.Count > 0)
          {
              foreach (Transform firepoint in firepoints)
              {
                  GameObject spawnedBullet = Instantiate(bullet, firepoint.position, firepoint.rotation);

                  Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();

                  if (rb != null)
                  {
                      rb.velocity = firepoint.right * bulletSpeed; // Fire in the firepoint's direction
                  }
                  else
                  {
                      Debug.LogWarning("Rigidbody2D not found on bullet.");
                  }

                  Destroy(spawnedBullet, bulletLifeTime);
              }

              Debug.Log("Shotgun fired from " + firepoints.Count + " firepoints.");
          }
          else
          {
              Debug.LogError("Bullet is not assigned or no firepoints found.");
          }
      } */
}
