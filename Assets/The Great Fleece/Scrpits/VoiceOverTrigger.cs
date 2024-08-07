using System.Collections;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public AudioClip clipToPlay;
    //private bool hasPlayed = false; // Sesin �al�p �almad���n� kontrol etmek i�in

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //&& !hasPlayed
        {
            VoiceManager.Instance.PlayVoiceOver(clipToPlay);
            
            //StartCoroutine(PlayAudio());
        }
    }

    //private IEnumerator PlayAudio()
    //{
    //    hasPlayed = true; // Ses �al�nd�
    //    AudioSource.PlayClipAtPoint(clipToPlay, Camera.main.transform.position);
    //    yield return new WaitForSeconds(clipToPlay.length); // Sesin s�resince bekle
    //}
}
