using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeftBird : MonoBehaviour
{

    public GameObject lbird;
    private int frameCount = 0;
    public float lbirdHeight;
    public float randomHeight;

    private void FixedUpdate()
    {
        frameCount++;

        if (frameCount % 900 == 0)
        {
            if(Random.Range(1,100) > 50)
            {
                MakeLBird();
            }
        }

    }

    public void MakeLBird()
    {
        randomHeight = Random.Range(2, 5);
        lbirdHeight = Random.Range(1, 999);
        lbirdHeight = 1 * (lbirdHeight / 1000);
        lbirdHeight = lbirdHeight + randomHeight;
        string lbirdName = "Bird Flying From Left";

        GameObject newlbird = Instantiate(lbird);
        newlbird.name = lbirdName;
        newlbird.transform.position = new Vector2(-20, lbirdHeight);

    }
}
