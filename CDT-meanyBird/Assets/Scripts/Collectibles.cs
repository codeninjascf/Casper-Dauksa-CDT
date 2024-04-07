using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //If an object collides with a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add score
        Score.score++;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
