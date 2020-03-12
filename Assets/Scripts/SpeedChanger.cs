using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedChanger : MonoBehaviour
{
    public NavMeshAgent agent;

    [Range(0, 100)]
    public float desiredSpeed = 1;

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            agent.speed = desiredSpeed;
        }
        catch (System.Exception)
        {
            print("No navmesh agent on this - what's it doing moving?!");
            throw;
        }
    }
}
