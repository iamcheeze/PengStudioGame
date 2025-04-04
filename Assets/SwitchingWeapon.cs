using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWeapon : MonoBehaviour
{
    public GunLogic gunLogic;  // Reference to the GunLogic script
    public ShotgunLogic shotgunLogic;  // Reference to the ShotgunLogic script
    public RocketLauncherLogic rocketLauncherLogic;  // Reference to the RocketLauncher script
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    public Sprite gunSprite;
    public Sprite shotgunSprite;
    public Sprite rocketLauncherSprite;

    private void Update()
    {
        // Switch to GunLogic (1 key press)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToGunLogic();
        }

        // Switch to ShotgunLogic (2 key press)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToShotgunLogic();
        }
        // Switch to ShotgunLogic (3 key press)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchToRocketLauncherLogic();
        }
    }

    // Enable GunLogic and disable ShotgunLogic
    void SwitchToGunLogic()
    {
        if (gunLogic != null)
        {
            gunLogic.enabled = true;  // Enable the GunLogic script
        }

        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = false;  // Disable the ShotgunLogic script
        }

        if (rocketLauncherLogic != null)
        {
            rocketLauncherLogic.enabled = false;  // Disable the RocketLauncherLogic script
        }

        if (spriteRenderer != null && gunSprite != null)
        {
            spriteRenderer.sprite = gunSprite; // Sprite switch
        }

        Debug.Log("Switched to GunLogic.");
    }

    // Enable ShotgunLogic and disable GunLogic
    void SwitchToShotgunLogic()
    {
        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = true;  // Enable the ShotgunLogic script
        }

        if (gunLogic != null)
        {
            gunLogic.enabled = false;  // Disable the GunLogic script
        }

        if (rocketLauncherLogic != null)
        {
            rocketLauncherLogic.enabled = false;  // Disable the RocketLauncherLogic script
        }

        if (spriteRenderer != null && shotgunSprite != null)
        {
            spriteRenderer.sprite = shotgunSprite; // Sprite switch
        }
        Debug.Log("Switched to ShotgunLogic.");
    }
    void SwitchToRocketLauncherLogic()
    {
        if (rocketLauncherLogic != null)
        {
            rocketLauncherLogic.enabled = true;  // Disable the RocketLauncherLogic script
        }

        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = false;  // Enable the ShotgunLogic script
        }

        if (gunLogic != null)
        {
            gunLogic.enabled = false;  // Disable the GunLogic script
        }

        if (spriteRenderer != null && rocketLauncherSprite != null)
        {
            spriteRenderer.sprite = rocketLauncherSprite; // Sprite switch
        }
    }
}
