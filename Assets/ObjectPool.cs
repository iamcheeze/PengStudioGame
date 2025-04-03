using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledObjectsBullet = new List<GameObject>();
    private List<GameObject> pooledObjectsShotgunBullet = new List<GameObject>();

    private int amountToPoolBullet = 25;
    private int amountToPoolShotgunBullet = 30;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shotgunBulletPrefab;
    
    public int maxBullets = 0;
    public int shotgunMaxBullets = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    } 
    // Shotgun stuff
    public bool ShotgunCanShoot()
    {
        return shotgunMaxBullets > 0;
    }

    public void UseShotgunBullet()
    {
        if (shotgunMaxBullets > 0)
        {
            shotgunMaxBullets--;
            Debug.Log("Bullet fired! Bullets remaining: " + shotgunMaxBullets);
        }
        else
        {
            Debug.LogWarning("No bullets left! Sacrifice needed.");
        }
    }
  // Normal gun stuff 
    public bool CanShoot()
    {
        return maxBullets > 0;
    }

    public void UseBullet()
    {
        if (maxBullets > 0)
        {
            maxBullets--;
            Debug.Log("Bullet fired! Bullets remaining: " + maxBullets);
        }
        else
        {
            Debug.LogWarning("No bullets left! Sacrifice needed.");
        }
    }
      public void Sacrifice()
    {
        maxBullets += 15;
        shotgunMaxBullets +=1;
        Debug.Log("Sacrifice made! Current bullets: " + maxBullets + " Current shotgun bullets: " + shotgunMaxBullets);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPoolBullet; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjectsBullet.Add(obj);
        }

        for (int i = 0; i < amountToPoolShotgunBullet; i++)
        {
            GameObject obj = Instantiate(shotgunBulletPrefab);
            obj.SetActive(false);
            pooledObjectsShotgunBullet.Add(obj);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < pooledObjectsBullet.Count; i++)
        {
            if (!pooledObjectsBullet[i].activeInHierarchy)
            {
                return pooledObjectsBullet[i];
            }
        }
        return null;
    }

    public GameObject GetPooledShotgunBullet()
    {
        for (int i = 0; i < pooledObjectsShotgunBullet.Count; i++)
        {
            if (!pooledObjectsShotgunBullet[i].activeInHierarchy)
            {
                return pooledObjectsShotgunBullet[i];
            }
        }
        return null;
    }
    // TEMPORARY sacrifice system so I can actually test the script out
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Change KeyCode as needed
        {
            Sacrifice();
        }
    }
}
