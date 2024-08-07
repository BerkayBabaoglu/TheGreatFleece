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
            if (_instance == null)
            {
                Debug.LogError("Voice Manager is null!");
            }
            return _instance;
        }
    }

    public AudioSource voiceSource;
    public AudioSource music;
    private HashSet<AudioClip> playedClips = new HashSet<AudioClip>(); // �al�nan ses dosyalar�n� tutan set

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        if (!playedClips.Contains(clipToPlay))
        {
            voiceSource.loop = false; // Ses dosyas�n�n bir kere �al�nmas�n� sa�la
            voiceSource.clip = clipToPlay;
            voiceSource.Play();
            playedClips.Add(clipToPlay); // �al�nan ses dosyas�n� sete ekle
        }
    }

    public void PlayMusic()
    {
        music.loop = true; // Ambiyans m�zi�in loop yapmas�n� sa�la
        music.Play();
    }
}