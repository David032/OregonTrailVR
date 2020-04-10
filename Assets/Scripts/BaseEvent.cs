using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseEvent : MonoBehaviour
{
    public bool amAtChallengePoint;
    protected NavMeshAgent navigationAgent;
    protected ExitController exitController;

    // Start is called before the first frame update
    void Start()
    {
        navigationAgent = GetComponentInParent<NavMeshAgent>();
        exitController = GetComponentInParent<ExitController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navigationAgent.isStopped)
        {
            amAtChallengePoint = true;
        }

        if (amAtChallengePoint)
        {
            GetComponent<ViewboxController>().amActive = true;
        }


    }

    public void gotoExit(Vector3 exitLocation) 
    {
        navigationAgent.SetDestination(exitLocation);
    }
    public void gotoExit(Transform exitTransform) 
    {
        navigationAgent.SetDestination(exitTransform.position);
    }
    public void gotoExit(GameObject exitObject) 
    {
        navigationAgent.SetDestination(exitObject.transform.position);
    }

    public void warpFix(Transform warpLocation) 
    {
        navigationAgent.Warp(warpLocation.position);
    }


}
