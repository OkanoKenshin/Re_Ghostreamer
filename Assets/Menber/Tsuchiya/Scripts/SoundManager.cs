using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] List<AudioSource> seAudioSources; // ������SE�Đ��p�̃I�[�f�B�I�\�[�X

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;


    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    public static SoundManager Instance { get; private set; }

    private Dictionary<SESoundData.SE, float> lastPlayedTime = new Dictionary<SESoundData.SE, float>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // ����������SE�I�[�f�B�I�\�[�X���v�[���ɒǉ�
        seAudioSources = new List<AudioSource>();
        for (int i = 0; i < 5; i++) // �����l�Ƃ���5��SE�I�[�f�B�I�\�[�X���쐬
        {
            AudioSource newSEAudioSource = gameObject.AddComponent<AudioSource>();
            seAudioSources.Add(newSEAudioSource);
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }

    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        if (!CanPlaySE(se))
        {
            return;
        }

        AudioSource seAudioSource = GetAvailableSEAudioSource();
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
        lastPlayedTime[se] = Time.time;
    }

    private bool CanPlaySE(SESoundData.SE se)
    {
        if (lastPlayedTime.ContainsKey(se))
        {
            float currentTime = Time.time;
            float timeSinceLastPlay = currentTime - lastPlayedTime[se];
            if (timeSinceLastPlay < 0.8f) // �����Đ���h�����߂̎��ԊԊu
            {
                return false;
            }
        }
        return true;
    }

    private AudioSource GetAvailableSEAudioSource()
    {
        foreach (AudioSource audioSource in seAudioSources)
        {
            if (!audioSource.isPlaying)
            {
                return audioSource;
            }
        }

        // ���ׂẴI�[�f�B�I�\�[�X���Đ����̏ꍇ�́A�V�����I�[�f�B�I�\�[�X���쐬���Ēǉ�
        AudioSource newSEAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSources.Add(newSEAudioSource);
        return newSEAudioSource;
    }
}


[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        //���x��
        Title, 
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        //���x��
        Ghost,
        GhostBarrier,
        Streamer,
        Streamer2,
        field,
        field2,
        field3,
        field4,
        other,
        other2,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

