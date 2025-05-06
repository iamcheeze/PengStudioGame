using UnityEngine;

public class CrawlerPatrol : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;                     // Patrol movement speed.
    public float stuckTurnThreshold = 0.1f;      // If horizontal speed falls below this, consider the crawler "stuck."
    public float checkStuckInterval = 0.5f;      // How frequently (in seconds) to check for low speed.

    [Header("Layer Settings")]
    public LayerMask platformLayer;              // Set this in the Inspector (should include your moving platform layer).

    private Rigidbody2D rb;
    private bool movingRight = true;
    private float lastStuckCheckTime;
    private bool onPlatform = false;             // Tracks whether the crawler is touching a Platform.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastStuckCheckTime = Time.time;
    }

    void Update()
    {
        Patrol();

        // Only check for low movement (and flip) if the crawler is NOT on a platform.
        if (!onPlatform)
        {
            if (Time.time - lastStuckCheckTime >= checkStuckInterval)
            {
                float horizontalSpeed = Mathf.Abs(rb.velocity.x);
                if (horizontalSpeed < stuckTurnThreshold)
                {
                    movingRight = !movingRight;  // Reverse direction when nearly stopped.
                }
                lastStuckCheckTime = Time.time;
            }
        }
    }

    // Patrol movement using Rigidbody2D velocity.
    private void Patrol()
    {
        float moveDir = movingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveDir * speed, rb.velocity.y);
    }

    // When the crawler collides with a platform, mark it as "on platform."
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Using bit shifting to check if collision object is in the platformLayer mask.
        if (((1 << collision.gameObject.layer) & platformLayer) != 0)
        {
            onPlatform = true;
        }
    }

    // When the crawler stops colliding with a platform, mark it as off platform.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & platformLayer) != 0)
        {
            onPlatform = false;
        }
    }
}
