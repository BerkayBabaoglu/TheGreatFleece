using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class CoinSystem : MonoBehaviour
{
    public Camera mainCamera;
    public List<NavMeshAgent> securityGuards;
    public GameObject coinPrefab;
    public AudioClip coinDropSound;
    public int coinLimit = 1;

    private AudioSource audioSource;
    private int coinsDropped = 0;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && coinsDropped < coinLimit) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                MoveGuardsToPosition(hit.point);
                SpawnCoin(hit.point);
                PlayCoinDropSound();
                coinsDropped++;
            }
        }
    }

    void MoveGuardsToPosition(Vector3 position)
    {
        foreach (NavMeshAgent guard in securityGuards)
        {
            if (guard != null)
            {
                guard.SetDestination(position);
            }
        }
    }

    void SpawnCoin(Vector3 position)
    {
        Instantiate(coinPrefab,position, Quaternion.identity);
    }

    void PlayCoinDropSound()
    {
        audioSource.PlayOneShot(coinDropSound);
    }
}