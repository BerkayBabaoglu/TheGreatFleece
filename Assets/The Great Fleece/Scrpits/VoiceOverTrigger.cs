using System.Collections;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public AudioClip clipToPlay;
    //private bool hasPlayed = false; // Sesin çalýp çalmadýðýný kontrol etmek için

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
    //    hasPlayed = true; // Ses çalýndý
    //    AudioSource.PlayClipAtPoint(clipToPlay, Camera.main.transform.position);
    //    yield return new WaitForSeconds(clipToPlay.length); // Sesin süresince bekle
    //}
}
