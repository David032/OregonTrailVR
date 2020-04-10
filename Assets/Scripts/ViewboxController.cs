using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewboxController : MonoBehaviour
{
    BoxCollider viewbox;
    public bool amActive = false;
    void Start()
    {
        viewbox = GetComponent<BoxCollider>();
        viewbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (amActive)
        {
            viewbox.enabled = true;
        }
    }
}
