using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformRight : MonoBehaviour
{
    [SerializeField] private float speed = -2f;
    [SerializeField] private float resetX = -10f;
    [SerializeField] private float rightBound = 10f;

    private Vector3 lastPosition;
    private List<Transform> passengers = new List<Transform>();

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 movement = Vector3.left * speed * Time.deltaTime;
        transform.Translate(movement);

        foreach (Transform passenger in passengers)
        {
            Vector3 localMovement = passenger.InverseTransformDirection(movement); // Prevent rotation-related issues
            passenger.Translate(localMovement);
        }

        if (transform.position.x > rightBound)
        {
            passengers.Clear(); // Clear passengers when resetting position
            Vector3 pos = transform.position;
            pos.x = resetX;
            transform.position = pos;

            // Also move passengers
            foreach (Transform passenger in passengers)
            {
                Vector3 passengerPos = passenger.position;
                passengerPos.x = pos.x + (passenger.position.x - lastPosition.x);
                passenger.position = passengerPos;
            }
        }

        lastPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Enemy"))
        {
            if (!passengers.Contains(collision.transform))
            {
                passengers.Add(collision.transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (passengers != null)
        {
            passengers.Remove(collision.transform);
        }
    }
}
