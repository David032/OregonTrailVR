using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechChanger : MonoBehaviour
{
    AudioClip introAudio;
    public AudioClip challengeAudio;
    public AudioClip exitAudio;

    public AudioSource compainion;
    public ViewboxController player;

    // Start is called before the first frame update
    void Start()
    {
        introAudio = compainion.clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isMoving && introAudio == compainion.clip)
        {
            compainion.clip = challengeAudio;
            compainion.Play();
        }
        else if (player.isMoving && compainion.clip == challengeAudio)
        {
            compainion.clip = exitAudio;
            compainion.Play();
        }
    }
}
