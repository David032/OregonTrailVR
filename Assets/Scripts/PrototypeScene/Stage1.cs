using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Stage 1 for the prototype scene
/// Roll-in through to finding the obstacle
/// </summary>
public class Stage1 : MonoBehaviour
{
    public GameObject targetPoint;

    NavMeshAgent playerAgent;
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        playerAgent.speed = 2f;
        playerAgent.SetDestination(targetPoint.transform.position);
    }

    void Update()
    {
        
    }
}
