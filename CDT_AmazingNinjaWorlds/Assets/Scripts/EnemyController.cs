using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float jumpForce = 7f;
    public AudioSource jumpAudio;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        jumpAudio.Play();
    }
}
