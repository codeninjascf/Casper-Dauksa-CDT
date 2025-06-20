using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level level;
    public GridManager gridManager;

    private bool _gameEnded;

    public UIManager uiManager;

    void Start()
    {
        _gameEnded = false;

        if (level.type == LevelType.Moves)
        {
            uiManager.criteriaInfoText.text = "MovesRemaining";
        }
        else if (level.type == LevelType.Time)
        {
            uiManager.criteriaInfoText.text = "Time Remaining";
        }

        uiManager.highScoreNumber.text = "Time Remaining:";
        uiManager.gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (level.type == LevelType.Moves)
        {
            uiManager.criteriaNumber.text = level.MovesRemaning.ToString();
        }
        else if (level.type == LevelType.Time)
        {
            double timeRemaining = Math.Max(level.TimeRemaning, 0);
            TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
            uiManager.criteriaNumber.text = time.ToString(@"mm\:ss");
        }
        
        int starsAchieved = level.StarAchieved(gridManager.Score); 

        uiManager.UpdateScores(gridManager.Score);
        uiManager.UpdateStars(starsAchieved);

        if (level.GameOver && gridManager.MoveComplete && !_gameEnded)
            {
                _gameEnded = true;

            gridManager.GameActive = false;

            string gameOverText = starsAchieved switch
            {
                0 => "Try Again",
                1 => "good Job",
                2 => "Excellent",
                3 => "Perfect"
            };

            uiManager.gameOverText.text = gameOverText;
            uiManager.newHighScoreText.SetActive(gridManager.Score > level.HighScore);
            uiManager.gameOverMenu.SetActive(true);

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