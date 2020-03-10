using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsoluteRainController : MonoBehaviour
{

    // Use this for initialization
    private ParticleSystem ps;
    [Range(1.0f, 10f)]
    public float Lifetime = 1.0f;
    [Range(1.0f, 25f)]
    public float MinSpeed = 10f;
    [Range(1.0f, 25f)]
    public float MaxSpeed = 15f;
    [Range(1.0f, 10f)]
    public float Duration = 5f;
    [Range(100.0f, 1000f)]
    public float Heaviness = 200f;

    void Start ()
    {
        ps = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        var main = ps.main;
        var emission = ps.emission;
        main.startLifetime = Lifetime;
        main.startSpeed = MinSpeed;
        main.startSpeedMultiplier = MaxSpeed;
        main.duration = Duration;
        emission.rateOverTime = Heaviness;
    }
}
