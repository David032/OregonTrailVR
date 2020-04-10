using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExitController : MonoBehaviour
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
        playerAgent = GetComponent<NavMeshAgent>();
        playerAgent.speed = 2f;
        playerAgent.SetDestination(targetPoint.transform.position);
    }
    void Awake()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        playerAgent.speed = 2f;
        playerAgent.SetDestination(targetPoint.transform.position);
    }
}
