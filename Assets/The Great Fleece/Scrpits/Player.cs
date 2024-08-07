using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    public NavMeshAgent agent;
    private Animator animator;
    public Camera playerCamera;
    private Vector3 _target;
    public int coinHakki = 1;

    public GameObject coinPrefab;
    public AudioClip coinSoundEffect;

    public List<NavMeshAgent> guards = new List<NavMeshAgent>();
    private int coinLimit = 0;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                agent.SetDestination(hitInfo.point);
                animator.SetBool("Walk", true);
                _target = hitInfo.point;
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target);

        if (distance < 1.0f)
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && coinLimit < coinHakki)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;

            if (Physics.Raycast(rayOrigin, out hitinfo))
            {

                animator.SetTrigger("Throw");
                Instantiate(coinPrefab, hitinfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, transform.position);
                coinLimit++;
                SendCoinToAI(hitinfo.point);
            }
        }
    }

    void SendCoinToAI(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach (var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator currentAnimator = guard.GetComponent<Animator>();

            currentGuard.coinTossed = true;
            currentAgent.SetDestination(coinPos);
            currentAnimator.SetBool("Walk", true);
            currentGuard.coinPos = coinPos;

        }
    }
}



//public static class Actions
//{
//    public static Action<Transform> OnCoinTossed;
//}