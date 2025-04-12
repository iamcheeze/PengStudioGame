using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapyCannonLogic : MonoBehaviour
{
    public KeyCode input;
    public Transform spawnpoint;
    public float therapySpeed = 10f;
    public float shootDelay = 0.5f;
    
    private float timeSinceLastShot = 0f;

    void Update()
        {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(input) && timeSinceLastShot >= shootDelay)
        {
            FireTherapy(); 
            timeSinceLastShot = 0f;
        }

        if (Input.GetKey(input) && timeSinceLastShot >= shootDelay)
        {
            FireTherapy(); 
            timeSinceLastShot = 0f;
        }
    }
void FireTherapy()
    {
        if (ObjectPool.instance.TherapyCanShoot()) // Use therapy ammo check
        { 
            GameObject therapyObj = ObjectPool.instance.GetRandomTherapyObject();

            if (therapyObj != null && spawnpoint != null)
            {
                therapyObj.transform.position = spawnpoint.position;
                therapyObj.transform.rotation = spawnpoint.rotation;
                therapyObj.SetActive(true);

                Rigidbody2D rb = therapyObj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = spawnpoint.right * therapySpeed;
                }
                else
                {
                    Debug.LogWarning("Rigidbody2D not found on therapy object.");
                }
                ObjectPool.instance.UseTherapy();
            }
            else
            {
                Debug.Log("No therapy sessions left! Sacrifice needed."); 
            }
        }
    }  
} 
