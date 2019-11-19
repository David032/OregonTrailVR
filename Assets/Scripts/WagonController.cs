using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General player facing systems
/// Currently contains:
/// >Horse animation controller
/// </summary>

public class WagonController : MonoBehaviour
{
    public GameObject LeftHorse;
    public GameObject RightHorse;

    Animator LeftHorseAnim;
    Animator RightHorseAnim;

    void Start()
    {
        LeftHorseAnim = LeftHorse.GetComponent<Animator>();
        RightHorseAnim = RightHorse.GetComponent<Animator>();

        LeftHorseAnim.SetFloat("Speed_f", 0);
        RightHorseAnim.SetFloat("Speed_f", 0);
    }

}
