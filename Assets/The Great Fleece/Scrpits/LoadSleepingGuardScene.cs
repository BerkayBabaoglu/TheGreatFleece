using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSleepingGuardScene : MonoBehaviour
{
    public GameObject sleepingguardScene;
    public Camera mainCamera;
    public GameObject player;
    public GameObject sleepingGuard;
    public GameObject trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sleepingguardScene.SetActive(true);
        }
    }

    


}
