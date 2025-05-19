using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunAmmoShowcase : MonoBehaviour
{
    public SwitchingWeapon sW;
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI tmp2;
    public TextMeshProUGUI tmp3;
    public TextMeshProUGUI tmp4;


    void Update()
    {
        tmp.text = ObjectPool.instance.maxBullets.ToString();
        tmp2.text = ObjectPool.instance.shotgunMaxBullets.ToString();
        tmp3.text = ObjectPool.instance.maxRockets.ToString();
        tmp4.text = ObjectPool.instance.maxTherapy.ToString();
    }
}
