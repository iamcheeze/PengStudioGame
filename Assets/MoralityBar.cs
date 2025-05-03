using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoralityBar : MonoBehaviour
{
    public Transform fillBar; 
    public Transform lagBar; 
     public SpriteRenderer fillBarRenderer; // Reference to change the bar's color when morality is low
    public float maxWidth = 5f; // Max scale.x when full
    public float lagSpeed = 2f; // How fast the lagging bar catches up
       
    // Variables for pulsing effect when morality is low
    public float lowMoralityThreshold = 0.3f; // 30% threshold
    public float pulseSpeed = 3f;

    private float initialScaleY;
    private float initialScaleZ;
    private float targetWidth;
    private float lagCurrentWidth;
    private Color originalColor; // For color change at low morality

    void Start()
    {
        if (fillBar != null)
        {
            initialScaleY = fillBar.localScale.y;
            initialScaleZ = fillBar.localScale.z;
        }

        float percent = MoralitySystem.Instance.currentMorality / MoralitySystem.Instance.maxMorality;
        percent = Mathf.Clamp01(percent);
        lagCurrentWidth = percent * maxWidth;
        originalColor = fillBarRenderer.color;
    }

    void Update()
    {
        if (MoralitySystem.Instance == null || fillBar == null || lagBar == null) return;

        float percent = MoralitySystem.Instance.currentMorality / MoralitySystem.Instance.maxMorality;
        percent = Mathf.Clamp01(percent);
        targetWidth = percent * maxWidth;

        Vector3 newScale = new Vector3(targetWidth, initialScaleY, initialScaleZ);

        fillBar.localScale = newScale;

        if (targetWidth < lagCurrentWidth)
        {
            lagCurrentWidth = Mathf.MoveTowards(lagCurrentWidth, targetWidth, lagSpeed * Time.deltaTime);
        }
        else
        {
            lagCurrentWidth = targetWidth;
        }

        lagBar.localScale = new Vector3(lagCurrentWidth, initialScaleY, initialScaleZ);

        // In progress: Color change when low.
        if (fillBarRenderer != null)
        {
            if (percent < lowMoralityThreshold)
            {
                Color flash1 = Color.red;
                Color flash2 = new Color(0.5f, 0f, 0f);
                float t = Mathf.PingPong(Time.time * pulseSpeed, 1f);
                fillBarRenderer.color = Color.Lerp(flash1, flash2, t);
            }
            else
            {
                fillBarRenderer.color = originalColor;
            }
        }
    }
}

