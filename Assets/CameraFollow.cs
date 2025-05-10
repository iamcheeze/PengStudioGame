using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 2;
    public Vector2 followOffset = new Vector2(2, 1);
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private Vector3 targetPos;
    private float camHalfHeight;
    private float camHalfWidth;

    void Start() {
        camHalfHeight = Camera.main.orthographicSize;
        camHalfWidth = camHalfHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null) return;

        Vector3 playerVelocity = player.GetComponent<Rigidbody2D>()?.velocity ?? Vector2.zero;
        float offsetX = followOffset.x * Mathf.Sign(playerVelocity.x);
        float offsetY = followOffset.y * Mathf.Sign(playerVelocity.y);

        targetPos = new Vector3(
            player.position.x + offsetX,
            player.position.y + offsetY,
            transform.position.z
        );

        float clampedX = Mathf.Clamp(targetPos.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(targetPos.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);
        Vector3 clampedTarget = new Vector3(clampedX, clampedY, targetPos.z);

        transform.position = Vector3.Lerp(transform.position, clampedTarget, followSpeed * Time.deltaTime);
    }
}
