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
    public NavMeshAgent agent;

    private void Awake()
    {
        try
        {
            //agent = GetComponentInParent<NavMeshAgent>();
        }
        catch
        {
            print("FAILED TO GET AGENT!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        lookingAtRoute = other.gameObject;
        print(lookingAtRoute);

        if (lookingAtRoute == SafeRoute)
        {
            print("SAFE!");
            StartCoroutine(MakeYourDecision(safeExit.transform.position, other));
            print("SHOULD BE MOVIN'!");
        }
        if (lookingAtRoute == DangerousRoute)
        {
            print("DANGEROUS!");
            StartCoroutine(MakeYourDecision(dangerousExit.transform.position,other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lookingAtRoute = null;
    }

    IEnumerator MakeYourDecision(Vector3 endpoint, Collider other) 
    {
        print("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(4);
        if (lookingAtRoute == other.gameObject)
        {
            agent.SetDestination(endpoint);
        }
        print("Finished Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(1);
    }

}
