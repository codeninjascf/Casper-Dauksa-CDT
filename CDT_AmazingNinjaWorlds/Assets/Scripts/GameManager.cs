using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int levelNumber;
    public float respawnDelay = 1.5f;
    public string menuSceneName;
    public string nextLevelName;
    public bool shurikensEnabled;
    public string levelMusicName;

    public PlayerController player;
    public CameraFollow cam;
    public Transform[] checkpoints;
    public Transform[] collectibles;
    public GameObject deathParticles;
    public GameObject levelCompleteMenu;
    public RublesDisplay rubiesDisplay;
    public GameObject[] shurikenCollectibles;
   
    private int _currentCheckpoint;
    private bool[] _collectiblesCollected;
    private int _shurikens;

    private bool[] _collectablesCollected;

    private AudioManager _audioManager;

    public int Shurikens
    {
        get => _shurikens;
        set
        {
            _shurikens = value;
        }
    }

    void Start()
    {
        _currentCheckpoint = 0;
        _collectiblesCollected = new bool[3];

        Shurikens = 0;

        levelCompleteMenu.SetActive(false);
        rubiesDisplay.levelNumber = levelNumber;

        _audioManager = FindObjectOfType<AudioManager>();

        _audioManager.FindAudio(levelMusicName).loop = true;
        _audioManager.PlayAudio(levelMusicName);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void KillPlayer()
    {
        player.Disable();

        player.gameObject.SetActive(false);

        _audioManager.PlayAudio("PlayerDeath");

        GameObject particles = Instantiate(deathParticles, new
        Vector3(player.transform.position.x, player.transform.position.y),
        Quaternion.identity);
        Destroy(particles, 1f);

        StartCoroutine(ResetPlayer());
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        int checkpointNumber = Array.IndexOf(checkpoints, checkpoint);
        {
            if (checkpointNumber > _currentCheckpoint)
            {
                _currentCheckpoint = checkpointNumber;
                _audioManager.PlayAudio("ActivateCheckpoint");
            }
        }
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);

        Vector3 spawnPosition = checkpoints[_currentCheckpoint].position;

        if (checkpoints[_currentCheckpoint].localScale.y == -1)
        {
            player.GravityFlipped = true;
            spawnPosition += new Vector3(0, -player.spriteHeight, 0);
        }
        else
        {
            player.GravityFlipped = false;
        }

        Shurikens = 0;

        foreach(GameObject shurikenCollectible in shurikenCollectibles)
        {
            shurikenCollectible.SetActive(true);
        }

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

        _audioManager.PlayAudio("GemCollect");
    }

    public void ReachedGoal()
    {
        player.Disable();

        PlayerPrefs.SetInt("Level" + levelNumber + "_Complete", 1);
    
        for(int i =0; i < 3; i++)
        {
            if (_collectiblesCollected[i])
            {
                PlayerPrefs.SetInt("Level" + levelNumber + "_Gem" +
                    (i + 1), 1);
            }
        }
      _audioManager.PlayAudio("LevelComplete");

        levelCompleteMenu.SetActive(true);
       levelCompleteMenu.GetComponent<Animator>().SetTrigger("Activate");
       rubiesDisplay.UpdateRubies();
    }


    public void LoadMenu()
    {
        _audioManager.PlayAudio("ButtonClick");
        SceneManager.LoadScene(menuSceneName);
    }

    public void LoadNextLevel()
    {
        _audioManager.PlayAudio("ButtonClick");
        SceneManager.LoadScene(nextLevelName);
    }
}