using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BarthaSzabolcs.Tutorial_SpriteFlash;

public class EnemyCollision : MonoBehaviour
{
    public int maxHealth = 100;
    public float moralityValueOnCure = 10f;
    public bool wasCured = false;

    private int currentHealth;
    private SimpleFlash flashEffect;

    public float swordHitCooldown = 0.5f;
    private float lastSwordHitTime = -Mathf.Infinity;

    public Random3Sprite r3S;
    public Animator canim;
    public Animator canim2;
    public AudioSource source;

    void Start()
    {
        source = GameObject.Find("death").GetComponent<AudioSource>();
        currentHealth = maxHealth;
        flashEffect = GetComponent<SimpleFlash>();

        canim = GameObject.Find("Main Camera").GetComponent<Animator>();
        canim2 = GameObject.Find("Camera Duplicate").GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Only deactivate if it's a real bullet
        if (other.gameObject.layer == LayerMask.NameToLayer("BulletType") || other.CompareTag("BulletType"))
        {
            BulletInfo bullet = other.GetComponent<BulletInfo>();
            if (bullet != null)
            {
                Instantiate(r3S.particle, transform.position, transform.rotation);
                canim.Play("CameraShake");
                canim2.Play("CameraShake");
                TakeDamage(bullet.damage);
                other.gameObject.SetActive(false);
                return;
            }
        }

        // Sword check
        SwordLogic sword = other.GetComponent<SwordLogic>();
        if (sword != null && Time.time >= lastSwordHitTime + swordHitCooldown)
        {
            TakeDamage(sword.damage);
            lastSwordHitTime = Time.time;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " took damage. Current health: " + currentHealth);

        if (flashEffect != null)
        {
            float flashIntensity = Mathf.Lerp(0.2f, 1f, 1f - Mathf.Clamp01((float)currentHealth / maxHealth));
            flashEffect.Flash(flashIntensity);
        }

        if (currentHealth <= 0)
        {
            // To be added: Make sure the game object leaves the list
            wasCured = true;
            source.Play();
            Destroy(gameObject);
            Debug.Log(gameObject.name + " has died.");
        }
    }
    void OnDestroy()
    {
        if (wasCured && MoralitySystem.Instance != null)
        {
            MoralitySystem.Instance.GainMorality(gameObject);
        }
    }
}
