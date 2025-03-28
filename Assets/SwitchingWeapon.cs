using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWeapon : MonoBehaviour
{
    public GunLogic gunLogic;  // Reference to the GunLogic script
    public ShotgunLogic shotgunLogic;  // Reference to the ShotgunLogic script

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

        Debug.Log("Switched to ShotgunLogic.");
    }
}

