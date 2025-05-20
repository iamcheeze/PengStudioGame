using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingWeapon : MonoBehaviour
{
    public GunLogic gunLogic;  // Reference to the GunLogic script
    public ShotgunLogic shotgunLogic;  // Reference to the ShotgunLogic script
    public RocketLauncherLogic rocketLauncherLogic;  // Reference to the RocketLauncherLogic script
    public TherapyCannonLogic therapyCannonLogic;  // Reference to the TherapyCannonLogic script
    public GameObject sword;  // Reference to the GameObject sword
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    public Sprite gunSprite;
    public Sprite shotgunSprite;
    public Sprite rocketLauncherSprite;
    public Sprite therapyCannonSprite;

    public AudioSource s;

    public Image[] images;
    public TextMeshProUGUI[] texts;

    private void Update()
    {
        // Switch to GunLogic (1 key press)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToGunLogic();
            s.Play();
        }
        // Switch to ShotgunLogic (2 key press)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToShotgunLogic();
            s.Play();
        }
        // Switch to ShotgunLogic (3 key press)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchToRocketLauncherLogic();
            s.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchToTherapyCannonLogic();
            s.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchToSword();
            s.Play();
        }
    }

    // Enable GunLogic and disable ShotgunLogic
    void SwitchToGunLogic()
    {
        if (gunLogic != null)
        {
            gunLogic.enabled = true;  // Enable the GunLogic script
            images[0].color = new Color(1f, 1f, 1f, 1f);
            texts[0].color = new Color(1f, 1f, 1f, 1f);
        }

        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = false;  // Disable the ShotgunLogic script
            images[1].color = new Color(1f, 1f, 1f, 0.5f);
            texts[1].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (rocketLauncherLogic != null)
        {
            rocketLauncherLogic.enabled = false;  // Disable the RocketLauncherLogic script
            images[2].color = new Color(1f, 1f, 1f, 0.5f);
            texts[2].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (therapyCannonLogic != null)
        {
            therapyCannonLogic.enabled = false;  // Disable the TherapyCannonLogic script
            images[3].color = new Color(1f, 1f, 1f, 0.5f);
            texts[3].color = new Color(1f, 1f, 1f, 0.5f);
            images[4].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (sword != null)
        {
            sword.SetActive(false);  // Deactivate the Sword
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
            images[1].color = new Color(1f, 1f, 1f, 1f);
            texts[1].color = new Color(1f, 1f, 1f, 1f);
        }

        if (gunLogic != null)
        {
            gunLogic.enabled = false;  // Disable the GunLogic script
            images[0].color = new Color(1f, 1f, 1f, 0.5f);
            texts[0].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (rocketLauncherLogic != null)
        {
            rocketLauncherLogic.enabled = false;  // Disable the RocketLauncherLogic script
            images[2].color = new Color(1f, 1f, 1f, 0.5f);
            texts[2].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (therapyCannonLogic != null)
        {
            therapyCannonLogic.enabled = false;  // Disable the TherapyCannonLogic script
            images[3].color = new Color(1f, 1f, 1f, 0.5f);
            texts[3].color = new Color(1f, 1f, 1f, 0.5f);
            images[4].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (sword != null)
        {
            sword.SetActive(false);  // Deactivate the Sword
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
            images[2].color = new Color(1f, 1f, 1f, 1f);
            texts[2].color = new Color(1f, 1f, 1f, 1f);
        }

        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = false;  // Disable the ShotgunLogic script
            images[1].color = new Color(1f, 1f, 1f, 0.5f);
            texts[1].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (gunLogic != null)
        {
            gunLogic.enabled = false;  // Disable the GunLogic script
            images[0].color = new Color(1f, 1f, 1f, 0.5f);
            texts[0].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (therapyCannonLogic != null)
        {
            therapyCannonLogic.enabled = false;  // Disable the TherapyCannonLogic script
            images[3].color = new Color(1f, 1f, 1f, 0.5f);
            texts[3].color = new Color(1f, 1f, 1f, 0.5f);
            images[4].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (sword != null)
        {
            sword.SetActive(false);  // Deactivate the Sword
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
            images[3].color = new Color(1f, 1f, 1f, 1f);
            texts[3].color = new Color(1f, 1f, 1f, 1f);
        }

        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = false;  // Disable the ShotgunLogic script
            images[1].color = new Color(1f, 1f, 1f, 0.5f);
            texts[1].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (gunLogic != null)
        {
            gunLogic.enabled = false;  // Disable the GunLogic script
            images[0].color = new Color(1f, 1f, 1f, 0.5f);
            texts[0].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (rocketLauncherLogic != null)
        {
            rocketLauncherLogic.enabled = false;  // Disable the RocketLauncherLogic script
            images[2].color = new Color(1f, 1f, 1f, 0.5f);
            texts[2].color = new Color(1f, 1f, 1f, 0.5f);
            images[4].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (sword != null)
        {
            sword.SetActive(false);  // Deactivate the Sword
        }

        if (spriteRenderer != null && therapyCannonSprite != null)
        {
            spriteRenderer.sprite = therapyCannonSprite; // Sprite switch
        }
        Debug.Log("Switched to TherapyCannonLogic.");
    }
    void SwitchToSword()
    {
        if (sword != null)
        {
            sword.SetActive(true);  // Activate the Sword
            images[4].color = new Color(1f, 1f, 1f, 1f);
        }

        if (therapyCannonLogic != null)
        {
            therapyCannonLogic.enabled = false;  // Disable the TherapyCannonLogic script
            images[3].color = new Color(1f, 1f, 1f, 0.5f);
            texts[3].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (shotgunLogic != null)
        {
            shotgunLogic.enabled = false;  // Disable the ShotgunLogic script
            images[1].color = new Color(1f, 1f, 1f, 0.5f);
            texts[1].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (gunLogic != null)
        {
            gunLogic.enabled = false;  // Disable the GunLogic script
            images[2].color = new Color(1f, 1f, 1f, 0.5f);
            texts[2].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (rocketLauncherLogic != null)
        {
            rocketLauncherLogic.enabled = false;  // Disable the RocketLauncherLogic script
            images[0].color = new Color(1f, 1f, 1f, 0.5f);
            texts[0].color = new Color(1f, 1f, 1f, 0.5f);
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = null; // Sprite switch
        }
        Debug.Log("Switched to Sword.");
    }
}
