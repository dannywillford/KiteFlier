using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrass : MonoBehaviour
{

    public GameObject grass;
    public Sprite[] grassSprites;
    private int frameCount = 0;

    private void FixedUpdate()
    {
        frameCount++;

        if (frameCount % 400 == 0)
        {
            MakeGrass();
        }

    }

    public void MakeGrass()
    {
        string grassName = "Moving Grass";
        int arrayIdx = Random.Range(0, grassSprites.Length);
        Sprite grassSprite = grassSprites[arrayIdx];

        GameObject newGrass = Instantiate(grass);
        newGrass.name = grassName;
        newGrass.GetComponent<SpriteRenderer>().sprite = grassSprite;
        newGrass.transform.position = new Vector2(25, -4.6f);

    }
}
