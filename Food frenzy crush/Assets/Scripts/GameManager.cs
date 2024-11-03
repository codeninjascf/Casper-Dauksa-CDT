using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level level;
    public GridManager gridManager;

    private bool _gameEnded;


    void Start()
    {
        _gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(level.GameOver && gridManager.MoveComplete && !_gameEnded)
        {
            _gameEnded = true;

            gridManager.GameActive = false;

            level.UpdateHighScore(gridManager.Score);
            level.UpdateStarsAchieved(gridManager.Score);
        }
    }

    void LateUpdate()
    {
        if (gridManager.MadeMove)
        {
            level.MovesRemaning--;
        }
    }
}