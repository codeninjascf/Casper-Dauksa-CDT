using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public float respawnDelay = 1.5f;
    public PlayerController player;
    public CameraFollow cam;
    public Transform[] checkpoints;
    public Transform[] collectibles;
   
    private int _currentCheckpoint;
    private bool[] _collectiblesCollected;

    void Start()
    {
        _currentCheckpoint = 0;
        _collectiblesCollected = new bool[3];
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void KillPlayer()
    {
        player.Disable();

        player.gameObject.SetActive(false);
        StartCoroutine(ResetPlayer());
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        int checkpointNumber = Array.IndexOf(checkpoints, checkpoint);
        {
            if (checkpointNumber > _currentCheckpoint)
            {
                _currentCheckpoint = checkpointNumber;
            }
        }
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);

        Vector3 spawnPosition = checkpoints[_currentCheckpoint].position;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.Enable();
        player.gameObject.SetActive(true);
        cam.ResetView();
        player.transform.position = spawnPosition;
    }

    public void GotCollectible(Transform collectible)
    {
        int collectibleNumber = Array.IndexOf(collectibles, collectible);

        _collectiblesCollected[collectibleNumber] = true;
    }
}