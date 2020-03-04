using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedChanger : MonoBehaviour
{
    [Range(0, 100)]
    public float desiredSpeed = 1;

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.GetComponent<NavMeshAgent>().speed = desiredSpeed;
        }
        catch (System.Exception)
        {
            print("No navmesh agent on this - what's it doing moving?!");
            throw;
        }
    }
}
