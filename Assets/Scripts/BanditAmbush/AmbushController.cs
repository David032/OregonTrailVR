using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AmbushController : MonoBehaviour
{
    public GameObject SafeRoute;
    public GameObject safeExit;
    public GameObject DangerousRoute;
    public GameObject dangerousExit;


    GameObject lookingAtRoute;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        lookingAtRoute = other.gameObject;

        if (lookingAtRoute == SafeRoute)
        {
            MakeYourDecision();
            agent.SetDestination(safeExit.transform.position);
        }
        if (lookingAtRoute == DangerousRoute)
        {
            StartCoroutine(MakeYourDecision());
            agent.SetDestination(dangerousExit.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lookingAtRoute = null;
    }

    IEnumerator MakeYourDecision() 
    {
        yield return new WaitForSeconds(30f);
    }

}
