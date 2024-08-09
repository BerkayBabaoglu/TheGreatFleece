using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadSleepingGuardScene : MonoBehaviour
{
    public GameObject sleepingguardScene;
    public Camera mainCamera;
    public GameObject player;
    public GameObject sleepingGuard;
    public GameObject trigger;
    public GameObject keyCard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sleepingguardScene.SetActive(true);

            Vector3 spawnPosition = new Vector3(-2.92f, 0, -108.9f);
            Quaternion spawnRotation = Quaternion.Euler(0, 90f, 0);

            player.transform.position = spawnPosition;
            player.transform.rotation = spawnRotation;

            Destroy(keyCard);

        }
    }
}
