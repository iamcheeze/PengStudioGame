using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    public List<BoxCollider2D> bx2d = new List<BoxCollider2D>();
    public float time = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Downtime());
        }
        IEnumerator Downtime()
        {
            for (int i = 0; i < bx2d.Count; i++)
            {
                bx2d[i].enabled = false;
            }
            yield return new WaitForSeconds(time);
            for (int i = 0; i < bx2d.Count; i++)
            {
                bx2d[i].enabled = true;
            }
        }
    }
}
