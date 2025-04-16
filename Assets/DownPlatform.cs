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
            // Drop Player
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), true);

            yield return new WaitForSeconds(time);

            // Stop dropping Player
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), false);
        }
    }
}
