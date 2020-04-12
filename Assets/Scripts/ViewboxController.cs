using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewboxController : MonoBehaviour
{
    public GameObject challengeLocation;
    BoxCollider viewbox;
    public GameObject player;

    void Start()
    {
        viewbox = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, challengeLocation.transform.position) > 5)
        {
            viewbox.enabled = false;
        }
        else
        {
            viewbox.enabled = true;
        }
    }

}
