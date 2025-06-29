using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private int Direction
    {
        get
        {
            if (GameManager.GameOver)
            {
                return 0;
            }
            if (GameManager.Player.transform.position.x < transform.position.x)
            {
                return -1;
            }
            if (GameManager.Player.transform.position.x > transform.position.x)
            {
                return 1;
            }
            return 0;
        }
    }

    private void Start()
    {
        _rigidbody.velocity = Direction * moveSpeed * Vector2.right;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _rigidbody.velocity = Direction * moveSpeed * Vector2.right;
            _rigidbody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        void PnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _rigidbody.velocity = Direction * moveSpeed * Vector2.right;
                _rigidbody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }
    }
}
