using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform current = collision.transform;

        // Traverse up the hierarchy to see if any parent is on the "Platform" layer
        while (current != null)
        {
            if (current.gameObject.layer == LayerMask.NameToLayer("Platform"))
            {
                // Ignore this collision
                Collider2D thisCollider = GetComponent<Collider2D>();
                Collider2D otherCollider = collision.collider;

                Physics2D.IgnoreCollision(thisCollider, otherCollider);
                break;
            }

            current = current.parent;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.IsChildOf(transform))
        {
            Collider2D thisCollider = GetComponent<Collider2D>();
            Collider2D otherCollider = collision.collider;

            Physics2D.IgnoreCollision(thisCollider, otherCollider, false);
        }
    }
}
