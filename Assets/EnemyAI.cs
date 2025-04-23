using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Assign this in code or Inspector
    public float moveSpeed;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        
        // If player not assigned in Inspector, auto-find by tag
        if (player == null) {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.transform;
        }
    }

    private void Update() {
        float directionX = Mathf.Sign(player.position.x - transform.position.x); //calculates what direction for enemies to go to (what direction the player is basically)

        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y); //
    }
}