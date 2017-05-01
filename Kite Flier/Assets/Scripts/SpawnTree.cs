using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{

    public GameObject tree;
    public Sprite[] treeSprites;
    private int frameCount = 0;
    public float cloudHeight;
    public float randomHeight;

    private void FixedUpdate()
    {
        frameCount++;

        if (frameCount % 700 == 0)
        {
            if (Random.Range(1, 100) > 15)
            {
                MakeTree();
            }
        }

    }

    public void MakeTree()
    {
        randomHeight = Random.Range(1, 4);
        cloudHeight = Random.Range(1, 999);
        cloudHeight = -1 * (cloudHeight / 1000);
        cloudHeight = cloudHeight - randomHeight;
        string treeName = "Tree";
        int arrayIdx = Random.Range(0, treeSprites.Length);
        Sprite treeSprite = treeSprites[arrayIdx];

        GameObject newTree = Instantiate(tree);
        newTree.name = treeName;
        newTree.GetComponent<SpriteRenderer>().sprite = treeSprite;
        newTree.transform.position = new Vector2(25, cloudHeight);

    }
}
