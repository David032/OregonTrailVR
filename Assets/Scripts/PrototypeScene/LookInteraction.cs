using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookInteraction : MonoBehaviour
{
    public GameObject bridge;
    public GameObject exitPoint;
    public NavMeshAgent agent;
    public GameObject Player;

    public AudioClip challengeAudio;
    public AudioSource compainion;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InteractableTree")
        {
            other.gameObject.SetActive(false);
            print("Interacted");
            bridge.SetActive(true);
            agent.SetDestination(exitPoint.transform.position);
            print(agent.destination);
            Player.GetComponent<Stage2>().enabled = true;
            compainion.clip = challengeAudio;
            compainion.Play();
        }
    }

}
