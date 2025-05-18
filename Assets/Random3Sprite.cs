using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random3Sprite : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject[] particles;
    public SpriteRenderer sR;

    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 3);
        particle = particles[randomNumber];
        sR.sprite = sprites[randomNumber];
    }
}
