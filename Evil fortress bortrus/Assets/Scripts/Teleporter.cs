using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public int nextScene;
    public float teleportDelay = 2f;
    public GameObject completionMenu;
    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            completionMenu.SetActive(true);
            other.GetComponent<PlayerController>().Disable();
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(teleportDelay);
        SceneManager.LoadScene(nextScene);
    }
}