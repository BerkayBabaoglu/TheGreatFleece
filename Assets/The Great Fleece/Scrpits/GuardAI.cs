using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
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

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wayPoints.Count > 0 && wayPoints[currentTarget] != null)
        {
            _agent.SetDestination(wayPoints[currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < 1.0f && _targetReached == false)
            {
                _targetReached = true;
                StartCoroutine(WaitBeforeMoving());
            }
            else
            {
                if(reverse == true)
                {
                    currentTarget--;
                    if(currentTarget <= 0)
                    {
                        reverse = false;
                        currentTarget = 0;
                    }
                }
                else
                {
                    currentTarget++;
                }
            }

        }
    }
    IEnumerator WaitBeforeMoving()
    {
        if(currentTarget == 0)
        {
            yield return new WaitForSeconds(2.0f);
        }
        else if(currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(2.0f);
        }
        else
        {
            yield return null;
        }

        if(reverse == true)
        {
            currentTarget--;

            if (currentTarget == 0)
            {
                reverse = false;
                currentTarget = 0;
            }
        }
        else if(reverse == false)
        {
            currentTarget++;

            if (currentTarget == wayPoints.Count)
            {
                reverse = true;
                currentTarget--;
            }
        }
    }
}
