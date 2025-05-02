using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Assign this in code or Inspector
    public float moveSpeed;

    private Rigidbody2D rb;
    public float horizontal = 1;

    public float minX = -5f;
    public float maxX = 5f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        
        // If player not assigned in Inspector, auto-find by tag
        if (player == null) {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.transform;
        }
    }

    private void Update()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (transform.position.x <= minX && horizontal < 0)
        {
            horizontal = 1;
            LookOtherWay();
        }
        else if (transform.position.x >= maxX && horizontal > 0)
        {
            horizontal = -1;
            LookOtherWay();
        }
    }

    void LookOtherWay() {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.CompareTag("Barrier"))
    //     {
    //         horizontal *= -1;
    //         LookOtherWay();
    //     }
    // }
}