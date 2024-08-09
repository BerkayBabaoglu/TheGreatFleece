using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    public GameObject sleepingGuardCutScene;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sleepingGuardCutScene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }
}
