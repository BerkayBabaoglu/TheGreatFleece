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

    }
}
