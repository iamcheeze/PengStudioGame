using System.Collections.Generic;
using UnityEngine;

public class GetRandomObjectPosition : MonoBehaviour
{
    public float speed = 3f;
    List<Vector2> positions = new List<Vector2> {new Vector2(-5.1f, 1.9f), new Vector2(4.3f, 2.05f), new Vector2(6.5f, -2.3f)};
    System.Random rand = new System.Random();
    int positionIndex = 0;
    private void Update()
    {
        if (positionIndex > positions.Count-1)
        {
            positionIndex = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, positions[positionIndex], speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, positions[positionIndex]) < .2f)
        {
            positionIndex += 1;
        }
    }
}