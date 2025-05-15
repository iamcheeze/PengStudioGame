using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEdgeMarker : MonoBehaviour
{
    public float edgeYOffset = 0.2f; // Set the height that the edges register collisions above the platform
    public GameObject groundPlatform;
    void Start()
    {
        AddEdgeMarkersToPlatforms();
    }

    void AddEdgeMarkersToPlatforms()
    {
        GameObject[] platforms = FindObjectsOfType<GameObject>();

        foreach (GameObject platform in platforms)
        {
            bool isTargetPlatform = platform.layer == LayerMask.NameToLayer("Platform") || platform == groundPlatform;
            if (isTargetPlatform)
            {
                if (platform.transform.Find("LeftEdge") != null || platform.transform.Find("RightEdge") != null)
                    continue; // Skip if already added

                Bounds bounds = GetPlatformBounds(platform);
                if (bounds.size == Vector3.zero) continue;

                // Create LeftEdge
                GameObject leftEdge = new GameObject("LeftEdge");
                leftEdge.transform.parent = platform.transform;
                leftEdge.transform.position = new Vector3(bounds.min.x, bounds.center.y + edgeYOffset, platform.transform.position.z);
                AddTriggerCollider(leftEdge);
                
                // Create RightEdge
                GameObject rightEdge = new GameObject("RightEdge");
                rightEdge.transform.parent = platform.transform;
                rightEdge.transform.position = new Vector3(bounds.max.x, bounds.center.y + edgeYOffset, platform.transform.position.z);
                AddTriggerCollider(rightEdge);
            }
        }
    }

    void AddTriggerCollider(GameObject edge)
    {
        BoxCollider2D col = edge.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        col.size = new Vector2(0.1f, 1f); // Thin vertical trigger zone
        edge.layer = LayerMask.NameToLayer("EdgeTrigger"); 
    }
    
    Bounds GetPlatformBounds(GameObject platform)
    {
        Collider2D col = platform.GetComponent<Collider2D>();
        if (col != null)
        {
            return col.bounds;
        }
        else
        {
            Renderer rend = platform.GetComponent<Renderer>();
            return rend != null ? rend.bounds : new Bounds();
        }
    }
}
