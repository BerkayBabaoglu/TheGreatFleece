using System.Collections;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public AudioClip clipToPlay;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //&& !hasPlayed
        {
            VoiceManager.Instance.PlayVoiceOver(clipToPlay);
            
        }
    }
}
    //private IEnumerator PlayAudio()
    //{
    //    hasPlayed = true; // Ses çalýndý
    //    AudioSource.PlayClipAtPoint(clipToPlay, Camera.main.transform.position);
    //    yield return new WaitForSeconds(clipToPlay.length); // Sesin süresince bekle
    //}

