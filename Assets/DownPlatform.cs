using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    public float dropTime = 0.5f;

    private Collider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(DropThrough());
        }
    }

    IEnumerator DropThrough()
    {
        // Find which colliders to disable
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, playerCollider.bounds.size, 0f);

        foreach (var hit in hits) // Checking if it actually hit a platform or not
        {
            if (hit != playerCollider && hit.gameObject.layer == LayerMask.NameToLayer("Platform"))
            {
                Physics2D.IgnoreCollision(playerCollider, hit, true);
            }
        }

        yield return new WaitForSeconds(dropTime);

        foreach (var hit in hits) // Allows the Player to drop but not enemies
        {
            if (hit != playerCollider && hit.gameObject.layer == LayerMask.NameToLayer("Platform"))
            {
                Physics2D.IgnoreCollision(playerCollider, hit, false);
            }
        }
    }
}
