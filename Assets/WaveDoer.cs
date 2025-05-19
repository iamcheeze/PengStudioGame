using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveDoer : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public spawningSystem sS;

    void Update()
    {
        tmp.text = "Wave: " + (sS.waveNumber - 1).ToString();
    }
}
