using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public GameManager gameManager;
    public Transform target;
    public float smoothingTime = .2f;
    private Vector3 _velocity;
    public Vector3 cameraOffset;

    public float deathHeight = -2;
    public bool heightLimitActive;
    public float heightLimit = 16;
    private bool _following;
    private float _cameraHeight;

    void Start()
    {
        _following = true;
        _cameraHeight = transform.position.y -
            Camera.main.ViewportToWorldPoint(Vector3.zero).y;

        ResetView();
    }



    void Update()
    {
        _following = target.position.y > deathHeight &&
        (!heightLimitActive || target.position.y < heightLimit);

        if (target.gameObject.activeSelf && target.position.y <=
            deathHeight - _cameraHeight)
        {
            gameManager.KillPlayer();
        }

        if (target.gameObject.activeSelf && target.position.y >=
           heightLimit + _cameraHeight && heightLimitActive)
        {
            gameManager.KillPlayer();
        }
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetPos,
            ref _velocity, smoothingTime);

            targetPos = new Vector3(target.position.x, target.position.y,
               transform.position.z) + cameraOffset;
        }
    }





    public void ResetView()
    {
        transform.position = new Vector3(target.position.x,
            target.position.y, transform.position.z) + cameraOffset;
        _velocity = Vector3.zero;
    }
}