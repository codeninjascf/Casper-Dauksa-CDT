using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Defult Speed")]
    //Speed for the movement
    public float speed;

    // Start is called before the first frame update
    void Update()
    {
         //Transform the object to move to the left
         //according to the axis and speed
         transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
