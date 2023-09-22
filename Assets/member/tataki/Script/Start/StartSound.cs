using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title);
    }

    public void PlayStart()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}