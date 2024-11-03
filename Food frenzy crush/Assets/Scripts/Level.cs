using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public enum LevelType
{
    Time,
    Moves
}

public class Level: MonoBehaviour
{
    public LevelType type;

    public int levelCondition;
    public int firstStar;
    public int secondStar;
    public int thirdStar;

    private string _levelName;

    public int MovesRemaning { get; set; }
    public double TimeRemaning { get; set; }
    public int HighScore { get; set; }

    public bool GameOver => type == LevelType.Moves && MovesRemaning <= 0
    || type == LevelType.Time && TimeRemaning <= 0;
 
    public int StarAchieved(int score) => Convert.ToInt32(score >= firstStar) +
    Convert.ToInt32(score >= secondStar) + Convert.ToInt32(score >= thirdStar);

    public void UpdateHighScore(int score) => PlayerPrefs.SetInt(_levelName +
    "_HighScore", Math.Max(score, HighScore));

    public void UpdateStarsAchieved(int score) => PlayerPrefs.SetInt(_levelName +
    "_Stars", StarAchieved(score));


    void Awake()
    {
        _levelName = SceneManager.GetActiveScene().name;

        MovesRemaning = levelCondition;
        TimeRemaning = levelCondition;

        HighScore=PlayerPrefs.GetInt(_levelName + "_HighScore", 0);
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        TimeRemaning -= Time.deltaTime;
    }
}