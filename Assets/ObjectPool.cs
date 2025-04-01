using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledObjectsBullet = new List<GameObject>();
    private List<GameObject> pooledObjectsShotgunBullet = new List<GameObject>();

    private int amountToPoolBullet = 25;
    private int amountToPoolShotgunBullet = 15;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject shotgunBulletPrefab;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
}
