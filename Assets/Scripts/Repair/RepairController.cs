using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RepairController : MonoBehaviour
{
    public GameObject hammer;
    public GameObject nails;
    public GameObject jack;
    public GameObject ironBolts;

    public GameObject exitPoint;

    public bool hasHammer;
    public bool hasNails;
    public bool hasJack;
    public bool hasIronbolts;

    bool acquringItem = false;

    GameObject currentlyLookingAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!acquringItem)
        {
            print("Attempting to acquire " + currentlyLookingAt);
            StartCoroutine(acquireItem(currentlyLookingAt));
        }
        if (hasHammer && hasNails && hasJack && hasIronbolts)
        {
            print("Got everything");
            GetComponentInParent<NavMeshAgent>().SetDestination(exitPoint.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    currentlyLookingAt = other.gameObject;
    print("Am looking at " + currentlyLookingAt);  
    }

    private void OnTriggerExit(Collider other)
    {
        currentlyLookingAt = null;   
    }

    IEnumerator acquireItem(GameObject thing) 
    {
        acquringItem = true;
        yield return new WaitForSeconds(2);
        if (thing == currentlyLookingAt)
        {
            if (currentlyLookingAt == hammer)
            {
                hasHammer = true;
            }
            else if (currentlyLookingAt == nails)
            {
                hasNails = true;
            }
            else if (currentlyLookingAt == jack)
            {
                hasJack = true;
            }
            else if (currentlyLookingAt == ironBolts)
            {
                hasIronbolts = true;
            }
        }
        acquringItem = false;
        yield return new WaitForSeconds(2);
    }
}
