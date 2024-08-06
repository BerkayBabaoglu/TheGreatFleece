using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public AudioClip clipToPlay;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clipToPlay, Camera.main.transform.position);
            hasPlayed = true;
        }
    }

}
