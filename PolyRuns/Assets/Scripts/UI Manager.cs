using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
   
        public GameObject mainMenu;

    public GameObject gameOverMenu;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverHighScoreText;

    private bool _gameOver;
    private int _highScore;

    void start()
    {
        scoreText.gameObject.SetActive(false);
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);

        _gameOver = false;
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        scoreText.text = GameManager.Score.ToString();

        if (!_gameOver && GameManager.GameOver)
        {
            _gameOver = true;

            scoreText.gameObject.SetActive(false);
            gameOverMenu.SetActive(true);

            if (GameManager.Score > _highScore)
            {
                _highScore = GameManager.Score;
                PlayerPrefs.SetInt("HighScore", _highScore);
            }

            gameOverScoreText.text = "Score: " + _highScore;
            gameOverHighScoreText.text = "High Score: " + _highScore;
        }
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
        GameManager.StartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
