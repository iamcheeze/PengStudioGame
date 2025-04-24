using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Assign this in code or Inspector
    public float moveSpeed;

    private Rigidbody2D rb;
    public float horizontal = 1;

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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            horizontal *= -1;
        }
    }
}