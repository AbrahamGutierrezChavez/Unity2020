using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WayPointPatrol : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public Transform[] wayPoints;
    private int currentWayPointIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //navMeshAgent.SetDestination(wayPoints[currentWayPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWayPointIndex = (currentWayPointIndex + 1)%wayPoints.Length;
            //Debug.Log((currentWayPointIndex + 1) % wayPoints.Length);
            navMeshAgent.SetDestination(wayPoints[currentWayPointIndex].position);
            //Debug.Log("Ahora se dirige al wayPoint: "+wayPoints[currentWayPointIndex].name);
        }
    }
}
