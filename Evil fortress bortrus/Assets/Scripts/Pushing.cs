using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    public float pushPower = 2f;
    private bool _pushing;
    private Animator _animator;

    public AudioClip footsteps;
    public AudioClip boxSliding;

    private AudioSource _audioSource;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        StopPushing();
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic || hit.moveDirection.y < -0.3)
        {
            return;
        }

        _pushing = true;

        Vector3 pushDirection;

        if (Mathf.Abs(hit.moveDirection.x) > Mathf.Abs(hit.moveDirection.z))
        {
            pushDirection = new Vector3(hit.moveDirection.x, 0, 0);
            body.velocity = pushDirection * pushPower;

            _animator.SetBool("isPushing", true);
        }
        else
        {
            pushDirection = new Vector3(0, 0, hit.moveDirection.z);
            body.velocity = pushDirection * pushPower;

            _animator.SetBool("isPushing", true);
        }

        
        

        CancelInvoke("StopPushing");

        _audioSource.clip = boxSliding;
    }

    void StopPushing()
    {
        _animator.SetBool("isPushing", false);
        _pushing = false;

        _audioSource.clip = footsteps;
    }
}