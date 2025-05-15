using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoralityBar : MonoBehaviour
{
    public Transform fillBar; 
    public Transform lagBar; 
    public SpriteRenderer fillBarRenderer; // Reference to change the bar's color when morality is low
    public SpriteRenderer lagBarRenderer; // ``
    public float maxWidth = 5f; // Max scale.x when full
    public float lagSpeed = 2f; // How fast the lagging bar catches up
       
    // Variables for pulsing effect when morality is low
    public float lowMoralityThreshold = 0.3f; // 30% threshold
    public float pulseSpeed = 3f;

    private float initialScaleY;
    private float initialScaleZ;
    private float targetWidth;
    private float lagCurrentWidth;
    private Color originalFillColor; // For color change at low morality
    private Color originalLagColor;

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
        originalFillColor = fillBarRenderer.color;
        originalLagColor = lagBarRenderer.color;
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
                float t = Mathf.PingPong(Time.time * pulseSpeed, 1f);

                // Fill bar pulses between red and dark red
                if (fillBarRenderer != null)
                {
                    Color fillPulse = Color.Lerp(Color.red, new Color(0.5f, 0f, 0f), t);
                    fillBarRenderer.color = fillPulse;
                }

                // Lag bar pulses between bright red and light pink
                if (lagBarRenderer != null)
                {
                    Color lagPulse = new Color(0.8f, 0.3f, 0.3f, 0.75f);
                    lagBarRenderer.color = lagPulse;
                }
            }
            else
            {
                fillBarRenderer.color = originalFillColor;
                lagBarRenderer.color = originalLagColor;
            }
        }
    }
}

