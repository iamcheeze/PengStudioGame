using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    public int damage = 10;
    public GameObject particle;
    public Animator anim;
    public Animator anim2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(particle, other.transform.position, other.transform.rotation);
            anim.Play("CameraShake");
            anim2.Play("CameraShake");
        }
    }
}
