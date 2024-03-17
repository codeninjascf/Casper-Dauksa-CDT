using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f
    public float jumpForce = 15f;

    private Rigidbody2D _rigidbody;

    void start()
    {
        _Rigidbody2D2D _rigidbody;
    }

    void FixedUpdate()
    {
        float movement = moveSpeed * Input.GetAxis("Horizontal");

        Player.Turn(_rigidbody, movement);

        _rigidbody.position += movement * Time.deltaTime * Vector2.right;
    }

    private void OnCollisionEnter2D()
    {
        if (_rigidbody.velocity.y <= 0)
    }
    _rigidbody.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
        }
}
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
