using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour {

    public GameObject cloud;
    public Sprite[] cloudSprites;
    private int frameCount = 0;
    private int chance = 0;
    public float cloudSpeed;
    public float cloudHeight;
    public float randomHeight;

    private void FixedUpdate()
    {
        frameCount++;

        if(frameCount % 100 == 0)
        {
            chance = Random.Range(1, 100);

            if(chance > 50)
            {
                MakeRandomCloud();
            }
        }

    }

    public void MakeRandomCloud()
    {
        randomHeight = Random.Range(3, 5);
        cloudHeight = Random.Range(1, 999);
        cloudHeight = 1 * (cloudHeight / 1000);
        cloudHeight = cloudHeight + randomHeight;
        cloudSpeed = Random.Range(1, 99);
        cloudSpeed = -1 * (cloudSpeed / 100);
        cloudSpeed = cloudSpeed - 1;
        int arrayIdx = Random.Range(0, cloudSprites.Length);
        Sprite cloudSprite = cloudSprites[arrayIdx];
        string cloudName = cloudSprite.name;

        GameObject newCloud = Instantiate(cloud);

        newCloud.name = cloudName;
        newCloud.GetComponent<SpriteRenderer>().sprite = cloudSprite;
        newCloud.transform.position = new Vector2(20, cloudHeight);
        newCloud.GetComponent<CloudMovement>().speed = cloudSpeed;
        
    }
}
