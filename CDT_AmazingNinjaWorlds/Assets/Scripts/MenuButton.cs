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
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
    if (_locked) return;

    SceneManager.LoadScene(levelName);
    }
}