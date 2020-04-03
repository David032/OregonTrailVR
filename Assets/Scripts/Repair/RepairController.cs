using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RepairController : MonoBehaviour
{
    public GameObject hammer;
    public GameObject nails;
    public GameObject jack;
    public GameObject ironBolts;

    bool hasHammer;
    bool hasNails;
    bool hasJack;
    bool hasIronbolts;

    GameObject currentlyLookingAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentlyLookingAt = collision.gameObject; 
    }

    private void OnCollisionExit(Collision collision)
    {
        currentlyLookingAt = null;
    }
}
