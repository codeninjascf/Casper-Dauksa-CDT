using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Spawner spawner;
    public CameraFollow view;
    public UIManager uiManager;

    private bool _gameOver;

    private void Start;
    {
        spawner.Spawn();
    }

    private void Start;
    {
        if (Input.GetButtonDown("Fire1") && !_gameOver)
        {
            BlockMovement.CurrentBlock.Stop;
            if (BlockMovement.GameOver)
            {
                _gameOver = true;
            }

        }
        else
        {
            spawner.spawn();
            view.Hieght = spawner.GetNewHeight();
            uiManager.Score++;
        }
    }
}
}
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
