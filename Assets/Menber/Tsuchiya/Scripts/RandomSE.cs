using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSE : MonoBehaviour
{
   
    public List<AudioClip> soundEffects; // SEのリストをインスペクタから設定します
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        PlayRandomSE();
    }

    void PlayRandomSE()
    {
        if (soundEffects.Count > 0)
        {
            int randomIndex = Random.Range(0, soundEffects.Count);
            audioSource.clip = soundEffects[randomIndex];
            audioSource.Play();
        }
    }
}

