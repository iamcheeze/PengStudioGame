using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerMovement : MonoBehaviour
{
    public float speed = 2f;

    private bool movingRight = true;
    private Rigidbody2D rb;
    private float platformSpeed = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        float totalSpeed = speed + platformSpeed;
        rb.velocity = new Vector2(direction.x * totalSpeed, rb.velocity.y);

        Transform current = transform.parent;
        while (current != null)
        {
            FloatingPlatformLeft leftPlatform = current.GetComponent<FloatingPlatformLeft>();
            FloatingPlatformRight rightPlatform = current.GetComponent<FloatingPlatformRight>();

            if (leftPlatform != null)
            {
                platformSpeed = leftPlatform.speed;
                break;
            }
            else if (rightPlatform != null)
            {
                platformSpeed = rightPlatform.speed;
                break;
            }

            current = current.parent;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "LeftEdge" || other.name == "RightEdge")
        {
            movingRight = !movingRight;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (movingRight ? 1 : -1);
        transform.localScale = scale;
    }
}
