using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RublesDisplay : MonoBehaviour
{
    public int levelNumber;
    public GameObject[] rubies;

    void Start()
    {
        UpdateRubies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRubies()
    {
        gameObject.SetActive(PlayerPrefs.GetInt("Level" + levelNumber +
            "_Complete") != 0);
    
        for(int i =0; i < 3; i++)
        {
        rubies[i].SetActive(PlayerPrefs.GetInt("Level" + levelNumber +
            "_Gem" + (i + 1), 0) == 1);
        }
    }
}