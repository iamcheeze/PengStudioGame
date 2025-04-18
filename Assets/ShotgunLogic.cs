using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunLogic : MonoBehaviour
{
    public KeyCode input;
    public List<Transform> firepoints;
    public float bulletSpeed = 10f;
    public float shootDelay = 0.5f;

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
                }
                else
                {
                    Debug.LogWarning("No pooled shotgun bullet available.");
                }
            }
            ObjectPool.instance.UseShotgunBullet();
            // Debug.Log("Shotgun fired from " + firepoints.Count + " firepoints."); 
        }
        else
        {
            Debug.Log("No shotgun bullets left! Sacrifice needed.");
        }
    }
}
