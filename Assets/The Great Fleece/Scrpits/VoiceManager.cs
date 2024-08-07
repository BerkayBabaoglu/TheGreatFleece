using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    private static VoiceManager _instance;
    public static VoiceManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Audio Manager is null!");
            }
            return _instance;
        }
    }

    public AudioSource voiceSource;
    public AudioSource music;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        voiceSource.clip = clipToPlay;
        voiceSource.Play();
    }
    

    public void playMusic()
    {
        music.Play();
    }
}
