using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stage1Termination : MonoBehaviour
{
    public NavMeshAgent PlayerAgent;
    public NavMeshAgent agent;
    public GameObject Player;
    public AudioClip challengeAudio;
    public AudioSource compainion;
    //Fix for Stage1 as the cart is too big
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<NavMeshAgent>().destination.Set(other.transform.position.x, other.transform.position.y, other.transform.position.z);
        PlayerAgent.isStopped = true;
        Player.GetComponent<Stage1>().enabled = false;
        compainion.clip = challengeAudio;
        compainion.Play();
        print("Destroyed");
        Destroy(this);

    }
}
