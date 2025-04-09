using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWeapon : MonoBehaviour
{
    public GunLogic gunLogic;  // Reference to the GunLogic script
    public ShotgunLogic shotgunLogic;  // Reference to the ShotgunLogic script
    public RocketLauncherLogic rocketLauncherLogic;  // Reference to the RocketLauncherLogic script
    public TherapyCannonLogic therapyCannonLogic;  // Reference to the TherapyCannonLogic script
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    public Sprite gunSprite;
    public Sprite shotgunSprite;
    public Sprite rocketLauncherSprite;
    public Sprite therapyCannonSprite;

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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchToTherapyCannonLogic();
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

        if (therapyCannonLogic != null)
        {
            therapyCannonLogic.enabled = false;  // Disable the TherapyCannonLogic script
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

        if (therapyCannonLogic != null)
        {
            therapyCannonLogic.enabled = false;  // Disable the TherapyCannonLogic script
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
            rocketLauncherLogic.enabled = true;  // Enable the RocketLauncherLogic script
        }

        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = false;  // Disable the ShotgunLogic script
        }

        if (gunLogic != null)
        {
            gunLogic.enabled = false;  // Disable the GunLogic script
        }

        if (therapyCannonLogic != null)
        {
            therapyCannonLogic.enabled = false;  // Disable the TherapyCannonLogic script
        }

        if (spriteRenderer != null && rocketLauncherSprite != null)
        {
            spriteRenderer.sprite = rocketLauncherSprite; // Sprite switch
        }
        Debug.Log("Switched to RocketLauncherLogic.");
    }
    void SwitchToTherapyCannonLogic()
    {
        if (therapyCannonLogic != null)
        {
            therapyCannonLogic.enabled = true;  // Enable the TherapyCannonLogic script
        }

        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = false;  // Enable the ShotgunLogic script
        }

        if (gunLogic != null)
        {
            gunLogic.enabled = false;  // Disable the GunLogic script
        }

        if (rocketLauncherLogic != null)
        {
            rocketLauncherLogic.enabled = false;  // Disable the RocketLauncherLogic script
        }

        if (spriteRenderer != null && therapyCannonSprite != null)
        {
            spriteRenderer.sprite = therapyCannonSprite; // Sprite switch
        }
        Debug.Log("Switched to TherapyCannonLogic.");
    }
}
