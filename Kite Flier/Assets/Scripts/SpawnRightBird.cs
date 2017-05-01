using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRightBird : MonoBehaviour
{

    public GameObject rbird;
    private int frameCount = 0;
    public float rbirdHeight;
    public float randomHeight;

    private void FixedUpdate()
    {
        frameCount++;

        if (frameCount % 600 == 0)
        {
            if (Random.Range(1, 100) > 40)
            {
                MakeRBird();
            }
        }

    }

    public void MakeRBird()
    {
        randomHeight = Random.Range(2, 5);
        rbirdHeight = Random.Range(1, 999);
        rbirdHeight = 1 * (rbirdHeight / 1000);
        rbirdHeight = rbirdHeight + randomHeight;
        string rbirdName = "Bird Flying From Left";

        GameObject newrbird = Instantiate(rbird);
        newrbird.name = rbirdName;
        newrbird.transform.position = new Vector2(20, rbirdHeight);

    }
}
