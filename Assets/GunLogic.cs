using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public KeyCode input;
    public Transform spawnpoint;
    public float bulletSpeed = 10f;
    public float shootDelay = 0.5f;
    public float bulletLifeTime = 5f;

    private float timeSinceLastShot = 0f;

    void SpawnBullet()
    {
        if (ObjectPool.instance.CanShoot()) 
        {
            GameObject spawnedBullet = ObjectPool.instance.GetPooledBullet();

            if (spawnedBullet != null && spawnpoint != null)
            {
                spawnedBullet.transform.position = spawnpoint.position;
                spawnedBullet.transform.rotation = spawnpoint.rotation;
                spawnedBullet.SetActive(true);

                Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = spawnpoint.right * bulletSpeed;
                }
                else
                {
                    Debug.LogWarning("Rigidbody2D not found on bullet.");
                }

                ObjectPool.instance.UseBullet();

                // Start coroutine
                StartCoroutine(DisableBullet(spawnedBullet, bulletLifeTime));
            }
            else
            {
                Debug.LogWarning("No available bullets in the pool!");
            }
        }
        else
        {
            Debug.Log("No bullets left! Sacrifice needed.");
        }
    }

    // Coroutine to disable the bullet after a delay
    IEnumerator DisableBullet(GameObject bullet, float bulletLifeTime)
    {
        yield return new WaitForSeconds(bulletLifeTime);

        if (bullet != null)
        {
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        
        if (Input.GetKeyDown(input) && timeSinceLastShot >= shootDelay)
        {
            SpawnBullet();
            timeSinceLastShot = 0f;
        }

        if (Input.GetKey(input) && timeSinceLastShot >= shootDelay)
        {
            SpawnBullet();
            timeSinceLastShot = 0f;
        }
    }
}
//                    ;,_            ,
//                 _uP~"b          d"u,
//                dP'   "b       ,d"  "o
//                d"    , `b     d"'    "b
//              l] [    " `l,  d"       lb
//              Ol ?     "  "b`"=uoqo,_  "l
//            ,dBb "b        "b,    `"~~TObup,_
//          ,d" (db.`"         ""     "tbc,_ `~"Yuu,_
//        .d" l`T'  '=                      ~     `""Yu,
//      ,dO` gP,                           `u,   b,_  "b7
//     d?' ,d" l,                           `"b,_ `~b  "1
//   ,8i' dl   `l                 ,ggQOV",dbgq,._"  `l  lb
//  .df' (O,    "             ,ggQY"~  , @@@@@d"bd~  `b "1
// .df'   `"           -=@QgpOY""     (b  @@@@P db    `Lp"b,
//.d(                  _               "ko "=d_,Q`  ,_  "  "b,
//Ql         .         `"qo,._          "tQo,_`""bo ;tb,    `"b,
//qQ         |L           ~"QQQgggc,_.,dObc,opooO  `"~~";.   __,7,
//qp         t\io,_           `~"TOOggQV""""        _,dg,_ =PIQHib.
//`qp        `Q["tQQQo,_                          ,pl{QOP"'   7AFR`
//  `         `tb  '""tQQQg,_             p" "b   `       .;-.`Vl'
//             "Yb      `"tQOOo,__    _,edb    ` .__   /`/'|  |b;=;.__
//                          `"tQQQOOOOP""`"\QV;qQObob"`-._`\_~~-._
//                                """"    ._        /   | |oP"\_   ~\ ~\_~\
//                                        `~"\ic,qggddOOP"|  |  ~\   `\~-._
//                                          ,qP`"""|"   | `\ `;   `\   `\
//                               _        _,p"     |    |   `\`;    |    |
//                                 "boo,._dP"       `\_  `\    `\|   `\   ;
//                                 `"7tY~'            `\  `\    `|_   | Ts (this) script is giving me trauma.
