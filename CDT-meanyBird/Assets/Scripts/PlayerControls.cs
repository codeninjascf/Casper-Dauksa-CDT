using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Game manager object
    [Header("Game Controller Object for controlling the game")]
    public GameController gameController;
    [Header("Default velocity")]
    public float velocity = 1f;
    //Physics for the bird
    private Rigidbody2D rb;
    //height of the bird object on the y axis
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        //Game Controller component
        gameController = GetComponent<GameController>();
        //Speed for the game is at a playing state 
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        //Object Height equals the size of the heightof the sprite
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
     // If the left mouse button is clicked
     if (Input.GetMouseButtonDown(0))
        {
            //The bird will float up on the Y axis
            // and float back down on Y axis 
            rb.velocity = Vector2.up * velocity;
        }
    }

    //Function where the player collides with a object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="HighSpike"
        ||collision.gameObject.tag=="LowSpike"
        ||collision.gameObject.tag=="ground")
        {
           //GameOver function is called from the game manager
           GameObject.Find("GameController").GetComponent<GameController>().GameOver();
        }
    }
}
