using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledObjectsBullet = new List<GameObject>();
    private List<GameObject> pooledObjectsShotgunBullet = new List<GameObject>();
    private List<GameObject> pooledObjectsRocket = new List<GameObject>();
    private List<GameObject> pooledObjectsTherapyBook = new List<GameObject>();
    private List<GameObject> pooledObjectsTherapyMeditate = new List<GameObject>();
    private List<GameObject> pooledObjectsTherapyYoga = new List<GameObject>();

    private int amountToPoolBullet = 25;
    private int amountToPoolShotgunBullet = 30;
    private int amountToPoolRocket = 5;
    private int amountToPoolTherapyBook = 10;
    private int amountToPoolTherapyMeditate = 10;
    private int amountToPoolTherapyYoga = 10;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shotgunBulletPrefab;
    [SerializeField] private GameObject rocketPrefab; 
    [SerializeField] private GameObject therapyBookPrefab;
    [SerializeField] private GameObject therapyMeditatePrefab;
    [SerializeField] private GameObject therapyYogaPrefab;

    public int maxBullets = 0;
    public int shotgunMaxBullets = 0;
    public int maxRockets = 0;
    public int maxTherapy = 0;

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
    // Rocket Launcher stuff
    public bool RocketCanShoot()
    {
        return maxRockets > 0;
    }
    public void UseRocket()
    {
        if (maxRockets > 0)
        {
            maxRockets--;
            Debug.Log("Rocket fired! Rockets remaining: " + maxRockets);
        }
        else
        {
            Debug.LogWarning("No rockets left! Sacrifice needed.");
        }
    }
    // Therapy Cannon stuff
    public bool TherapyCanShoot()
    {
        return (maxTherapy > 0);
    }
       public void UseTherapy()
        {
            if (maxTherapy > 0)
            {
                maxTherapy--;
                Debug.Log("Therapy fired! Therapy Session remaining: " + maxTherapy);
            }
            else
            {
                Debug.LogWarning("No therapy sessions left!");
            }
        }
    public GameObject GetRandomTherapyObject()
    {
        List<System.Func<GameObject>> therapyGetters = new List<System.Func<GameObject>>()
        {
            GetPooledTherapyBook,
            GetPooledTherapyMeditate,
            GetPooledTherapyYoga
        };
        int startIndex = Random.Range(0, therapyGetters.Count); // Shuffle
        for (int i = 0; i < therapyGetters.Count; i++)
        {
            int index = (startIndex + i) % therapyGetters.Count;
            GameObject therapyObj = therapyGetters[index]();
            if (therapyObj != null)
            {
                return therapyObj;
            }
        }
        return null;
    }

    public void Sacrifice()
    {
        maxBullets += 15;
        shotgunMaxBullets += 3;
        maxRockets += 1;
        Debug.Log("Sacrifice made! Current bullets: " + maxBullets + " Current shotgun bullets: " + shotgunMaxBullets + " Current rockets: " + maxRockets);
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
        for (int i = 0; i < amountToPoolRocket; i++)
        {
            GameObject obj = Instantiate(rocketPrefab);
            obj.SetActive(false);
            pooledObjectsRocket.Add(obj);
        }
        for (int i = 0; i < amountToPoolTherapyBook; i++)
        {
            GameObject obj = Instantiate(therapyBookPrefab);
            obj.SetActive(false);
            pooledObjectsTherapyBook.Add(obj);
        }
        for (int i = 0; i < amountToPoolTherapyMeditate; i++)
        {
            GameObject obj = Instantiate(therapyMeditatePrefab);
            obj.SetActive(false);
            pooledObjectsTherapyMeditate.Add(obj);
        }
        for (int i = 0; i < amountToPoolTherapyYoga; i++)
        {
            GameObject obj = Instantiate(therapyYogaPrefab);
            obj.SetActive(false);
            pooledObjectsTherapyYoga.Add(obj);
        }
        // Refill Therapy Bullets
        StartCoroutine(RefillTherapyOverTime());
    }
    // Refill Therapy Bullets
    private IEnumerator RefillTherapyOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            if (maxTherapy < 10)
            {
                maxTherapy++;
                Debug.Log("Therapy refilled. Current therapy: " + maxTherapy);
            }
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

    public GameObject GetPooledRocket()
    {
        for (int i = 0; i < pooledObjectsShotgunBullet.Count; i++)
        {
            if (!pooledObjectsRocket[i].activeInHierarchy)
            {
                return pooledObjectsRocket[i];
            }
        }
        return null;
    }

    public GameObject GetPooledTherapyBook()
    {
        for (int i = 0; i < pooledObjectsTherapyBook.Count; i++)
        {
            if (!pooledObjectsTherapyBook[i].activeInHierarchy)
            {
                return pooledObjectsTherapyBook[i];
            }
        }
        return null;
    }

    public GameObject GetPooledTherapyMeditate()
    {
        for (int i = 0; i < pooledObjectsTherapyMeditate.Count; i++)
        {
            if (!pooledObjectsTherapyMeditate[i].activeInHierarchy)
            {
                return pooledObjectsTherapyMeditate[i];
            }
        }
        return null;
    }

    public GameObject GetPooledTherapyYoga()
    {
        for (int i = 0; i < pooledObjectsTherapyYoga.Count; i++)
        {
            if (!pooledObjectsTherapyYoga[i].activeInHierarchy)
            {
                return pooledObjectsTherapyYoga[i];
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
