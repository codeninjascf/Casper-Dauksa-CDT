using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target
    public float smoothingTime = .2f;
    private Vector3 _velocity

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 trargetPos = new Vector3(target.position.x,target.position.y,transform.position.z
            ref _velocity, smoothingTime);
    }
}