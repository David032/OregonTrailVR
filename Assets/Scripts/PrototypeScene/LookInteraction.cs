using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookInteraction : BaseEvent
{
    public GameObject bridge;
    public GameObject exitPoint;
    public NavMeshAgent agent;
    public GameObject player;

    public AudioClip challengeAudio;
    public AudioSource compainion;
    public AudioSource treeChop;

    public GameObject warpingFixPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InteractableTree")
        {
            other.gameObject.SetActive(false);
            treeChop.Play();
            bridge.SetActive(true);

            compainion.clip = challengeAudio;
            compainion.Play();

            exitController.enabled = true;
            GetComponentInParent<NavMeshAgent>().Warp(warpingFixPoint.transform.position);

        }
    }
}
