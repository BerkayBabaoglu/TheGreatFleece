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
    private HashSet<AudioClip> playedClips = new HashSet<AudioClip>(); // Çalýnan ses dosyalarýný tutan set

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        if (!playedClips.Contains(clipToPlay))
        {
            voiceSource.loop = false; // Ses dosyasýnýn bir kere çalýnmasýný saðla
            voiceSource.clip = clipToPlay;
            voiceSource.Play();
            playedClips.Add(clipToPlay); // Çalýnan ses dosyasýný sete ekle
        }
    }

    public void PlayMusic()
    {
        music.loop = true; // Ambiyans müziðin loop yapmasýný saðla
        music.Play();
    }
}