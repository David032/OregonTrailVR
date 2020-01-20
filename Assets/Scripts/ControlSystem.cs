using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlSystem : MonoBehaviour
{
    //If these objects aren't set, the manager will scream at you until they are - they are key for every scene
    public GameObject startingLocation;
    public GameObject challengeLocation;
    public GameObject finishLocation;
    public NavMeshData pathToTake;  //We don't actually need a refrence to the path, but this way it should be more obvious if something isn't working

    bool areKeyElementsSet = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckKeyElements();
    }

    private void CheckKeyElements()
    {
        if (startingLocation && challengeLocation && finishLocation && pathToTake != null)
        {
            areKeyElementsSet = true;
        }

        if (areKeyElementsSet == false)
        {
            if (startingLocation == null)
            {
                print("Failed to set starting location!");
            }
            if (challengeLocation == null)
            {
                print("Failed to designate challenge location!");
            }
            if (finishLocation == null)
            {
                print("Failed to set finishing location!");
            }
            if (pathToTake == null)
            {
                print("Navmesh for path may not be built");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!areKeyElementsSet)
        {
            CheckKeyElements();
        }
    }
}
