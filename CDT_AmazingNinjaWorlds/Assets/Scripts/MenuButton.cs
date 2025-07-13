using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public int previousLevelNumber;
    public string levelName;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;
    private bool _locked;
    private Image _image;
    private AudioManager _audioManager;

    void Start()
    {
        _image = GetComponent<Image>();

        if (previousLevelNumber == 0 || PlayerPrefs.GetInt("Level"
             + previousLevelNumber + "_Complete", 0) == 1)
        {
            _locked = false;
            _image.sprite = unlockedSprite;
        }
        else
        {
            _locked = true;
            _image.sprite = lockedSprite;
        }

        _audioManager = FindObjectOfType<AudioManager>();
        _audioManager.FindAudio("MenuMusic").loop = true;
        _audioManager.PlayAudio("MenuMusic");
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
     if (_locked) return;

        _audioManager.PlayAudio("ButtonClick");

        SceneManager.LoadScene(levelName);
    }
}