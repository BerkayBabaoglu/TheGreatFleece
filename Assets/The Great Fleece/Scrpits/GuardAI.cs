using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    private NavMeshAgent _agent;
    [SerializeField]
    private int currentTarget;
    private bool reverse;
    private bool _targetReached;

    public bool coinTossed = false;
    public Vector3 coinPos;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null && coinTossed == false)
        {
            _agent.SetDestination(wayPoints[currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < 1.0f && !_targetReached)
            {
                    if(currentTarget == 0)
                    {
                        _targetReached = true;
                        reverse = true;
                        animator.SetBool("Walk", false);
                        StartCoroutine(WaitBeforeMoving());
                    }
                    else if(currentTarget == wayPoints.Count - 1)
                    {
                        _targetReached = true;
                        reverse = true;
                        animator.SetBool("Walk", false);
                        StartCoroutine(WaitBeforeMoving());
                    }else
                    {
                        reverse = false;
                        UpdateCurrentTarget();
                    }
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);

            if (distance < 4.0f)
            {
                animator.SetBool("Walk", false);
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(2f);

        UpdateCurrentTarget();
        _targetReached = false;
    }

    private void UpdateCurrentTarget()
    {
        if (reverse==true && currentTarget == 0)
        {
            currentTarget++;
            animator.SetBool("Walk", true);
        }
        else if(reverse==true && currentTarget == wayPoints.Count - 1)
        {
            currentTarget--;
            animator.SetBool("Walk", true);
        }
        else if(reverse == false  && currentTarget == 0)
        {
            currentTarget++;
            animator.SetBool("Walk", true);
        }
        else if(reverse == false && currentTarget == wayPoints.Count - 1)
        {
            currentTarget--;
            animator.SetBool("Walk", true);
        }
        
    }
}
