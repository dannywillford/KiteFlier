using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public bool GameOver = false;
    public AudioClip death;
    public int treeCollisionAudio = 1;
    public int grassCollisionAudio = 1;
    public int birdCollisionAudio = 1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = death;
    }

    private void FixedUpdate()
    {
        if (GameOver == false)
        {
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(0.0f, moveVertical);

            rb.AddForce(movement);
        }
        else
        {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ceiling")
        {

        }
        else if (collider.gameObject.tag == "Tree")
        {
            GameOver = true;
            if (treeCollisionAudio == 1)
            {
                GetComponent<AudioSource>().Play();
                treeCollisionAudio = 0;
            }
        }
        else if (collider.gameObject.tag == "Bird")
        {
            GameOver = true;
            if (birdCollisionAudio == 1)
            {
                GetComponent<AudioSource>().Play();
                birdCollisionAudio = 0;
            }
        }
        else if (collider.gameObject.tag == "Grass")
        {
            GameOver = true;
            if (grassCollisionAudio == 1)
            {
                GetComponent<AudioSource>().Play();
                grassCollisionAudio = 0;
            }
        }
    }
}
