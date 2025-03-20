using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour
{
    public float speed = 3f;
    public float moveDistance = 10f;
    private Vector2 currentPosition;
    private Vector2 movement = Vector2.right;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            movement *= -1;
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    void Update()
    {
        transform.Translate(movement * speed * Time.deltaTime);
        currentPosition = transform.position;
    }

    
}
