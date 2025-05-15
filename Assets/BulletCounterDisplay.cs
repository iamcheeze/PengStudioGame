using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounterDisplay : MonoBehaviour
{
    public SwitchingWeapon weaponSwitcher;

    public Texture2D bulletIcon;
    public Texture2D shotgunIcon;
    public Texture2D rocketIcon;
    public Texture2D therapyIcon; // Bullet previews
    [SerializeField] private Color Bullet = new Color(0.92f, 0.945f, 0.27f);
    [SerializeField] private Color ShotgunBullet = new Color(1f, 0.05f, 0.1f);
    [SerializeField] private Color Rocket = new Color(0.05f, 0.7f, 0.13f);
    [SerializeField] private Color Therapy = new Color(1f, 1f, 1f);
                
    private GUIStyle style;

    private void Start()
    {
        style = new GUIStyle();
        style.fontSize = 32;
        style.alignment = TextAnchor.UpperLeft;
        style.wordWrap = false;
    }

    private void OnGUI()
    {
        string text = "";
        Texture2D iconToDraw = null;

        if (weaponSwitcher.gunLogic.enabled)
        {
            text = " " + ObjectPool.instance.maxBullets;
            style.normal.textColor = Bullet;
            iconToDraw = bulletIcon;
        }
        else if (weaponSwitcher.shotgunLogic.enabled)
        {
            text = " " + ObjectPool.instance.shotgunMaxBullets;
            style.normal.textColor = ShotgunBullet;
            iconToDraw = shotgunIcon;
        }
        else if (weaponSwitcher.rocketLauncherLogic.enabled)
        {
            text = " " + ObjectPool.instance.maxRockets;
            style.normal.textColor = Rocket;
            iconToDraw = rocketIcon;
        }
        else if (weaponSwitcher.therapyCannonLogic.enabled)
        {
            text = " " + ObjectPool.instance.maxTherapy;
            style.normal.textColor = Therapy;
            iconToDraw = therapyIcon;
        }

        GUIStyle shadowStyle = new GUIStyle(style);
        shadowStyle.normal.textColor = Color.black;

        Rect textRect = new Rect(40, 10, 400, 50);
        GUI.Label(new Rect(textRect.x + 2, textRect.y + 2, textRect.width, textRect.height), text, shadowStyle); // Shadow
        GUI.Label(textRect, text, style); // Main text
        // Icon
            if (iconToDraw != null)
        {
            Rect iconRect = new Rect(textRect.x - 30, textRect.y + 5, 32, 32); // Position/size of icon
            GUI.DrawTexture(iconRect, iconToDraw, ScaleMode.ScaleToFit, true);
        }
    }
}
