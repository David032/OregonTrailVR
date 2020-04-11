using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StageAudio : MonoBehaviour
{
    public NavMeshAgent PlayerAgent;
    public AudioClip[] wagonAudio;
    public AudioSource wagonSource;
    private bool travellingOnSnow;

    // Start is called before the first frame update
    void Start()
    {
        travellingOnSnow = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
        //Debug.Log(PlayerAgent.speed);
    }

    private void OnCollisionEnter (Collision other)
    {
        foreach (AudioClip currentClip in wagonAudio)
        {
            if (other.gameObject.tag == currentClip.name)
            {
                wagonSource.clip = wagonAudio[System.Array.IndexOf(wagonAudio, currentClip)];
                //Debug.Log("Travelling on " + currentClip.name);

                if (other.gameObject.tag == "Snow")
                {
                    travellingOnSnow = true;
                }
            }
        }
    }

    void CheckStatus()
    {
        //check if wagon is stopped or not
        if (PlayerAgent.isStopped == false)
        {
            if (wagonSource.isPlaying == false)
            {
                wagonSource.Play();
            }
        }

        else if (PlayerAgent.isStopped == true)
        {
            if (wagonSource.isPlaying == true)
            {
                wagonSource.Stop();
            }
        }


        if (travellingOnSnow == true)
        {
            if (PlayerAgent.speed == 2)
            {
                //wagonSource.clip = wagonAudio[0];
            }

            else if (PlayerAgent.speed == 10)
            {
                //wagonSource.clip = wagonAudio[1];
            }
        }
        //Debug.Log(PlayerAgent.isStopped);
        //Debug.Log(wagonSource.clip);
    }
}