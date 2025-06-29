using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Audio[] sounds;
    [System.Serializable]
    public struct Audio
    {
        public string name;
        public AudioSource audioSource;
        
    }

    public AudioSource FindAudio (string id)
    {
        foreach (Audio sound in sounds)
        {
            if (sound.name == id)
            {
                return sound.audioSource;
            }
        }
        return null;
    }

    public void PlayAudio(string id)
    {
        AudioSource Source = FindAudio(id);
        if (Source != null)
        {
            if (!Source.isPlaying)
            {
                Source.Play();
            }
        }
        else
        {
            Debug.LogWarning("No audio source was found with name " + id);
        }
    }


    public void StopAudio(string id)
    {
        AudioSource Source = FindAudio(id);

        if (Source != null)
        {
            if (!Source.isPlaying)
            {
                Source.Stop();
            }
        }
        else
        {
            Debug.LogWarning("No audio source was found with name " + id);
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
