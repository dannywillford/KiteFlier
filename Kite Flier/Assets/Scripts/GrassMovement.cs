using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMovement : MonoBehaviour
{
    public float speed = -0.5f;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector2(speed, 0) * Time.deltaTime);

    }
}
