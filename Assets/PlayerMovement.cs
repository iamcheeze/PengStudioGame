using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // idk what to make private, so everything is public
    public float jumpForce = 7f;
    public Rigidbody2D rb;
    public Vector2 movement;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input
        float moveX = Input.GetAxis("Horizontal");
        movement = new Vector2(moveX, 0);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if touching the ground
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}