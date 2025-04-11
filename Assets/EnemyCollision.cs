using UnityEngine;
using BarthaSzabolcs.Tutorial_SpriteFlash;

public class EnemyCollision : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private SimpleFlash flashEffect;
    void Start()
    {
        currentHealth = maxHealth;
        flashEffect = GetComponent<SimpleFlash>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BulletInfo bullet = other.GetComponent<BulletInfo>();
        if (bullet != null)
        {
            TakeDamage(bullet.damage);
            other.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " took damage. Current health: " + currentHealth);

        if (flashEffect != null)
        {
            flashEffect.Flash();
        }

        if (currentHealth <= 0)
        {
        Debug.Log(gameObject.name + " has died.");
        }
    }
}
