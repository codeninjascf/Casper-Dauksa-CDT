using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    public float pushPower = 2f;
    private bool _pushing;
    private Animator _animator;


    void Start()
    {
        _animator - GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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

        if (Mathf.Abs(ColliderHit.moveDirection.z))
        {
            pushDirection = new Vector3(hit.moveDirection.x, 0, 0,);
        }
        else
        {
            pushDirection = new Vector3(0, 0, hit.moveDirection.z);
    }
}
        Body.velocity = pushDirecting * pushPower;

        _animator.SetBool("isPushing", true);
    }
}