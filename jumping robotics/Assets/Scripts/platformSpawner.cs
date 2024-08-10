using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject mainCamera;

    public float startingHeight = -1f;
    public float distanceBtwPlatform = 2.5f;

    private float _lastYValue;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {

            SpawnPlatform(startingHeight + distanceBtwPlatform * i);
        }

        _lastYValue = mainCamera.transform.position.y;
    }

    void Update()
    {
        if (mainCamera.transform.position.y - _lastYValue >= distanceBtwPlatform)
        {
            SpawnPlatform(transform.position.y);
            _lastYValue = mainCamera.transform.position.y;
        }
    }


    void SpawnPlatform(float height)
    {
        GameObject platform = ObjectPooling.Instance.GetPlatform();
        platform.transform.position = new Vector3(0, height);
        platform.GetComponent<PlatfromController>().InitialisePlatform();
        platform.SetActive(true);
    }
}