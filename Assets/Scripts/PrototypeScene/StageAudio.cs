using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StageAudio : MonoBehaviour
{
    public NavMeshAgent PlayerAgent;
    public AudioClip[] wagonAudio;
    public AudioSource wagonSource;
    public GameObject viewBox;
    private bool travellingOnSnow;
    private bool travellingOnMountain;
    public bool hasStopped;

    // Start is called before the first frame update
    void Start()
    {
        travellingOnSnow = false;
        travellingOnMountain = false;
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

                else if (other.gameObject.tag == "Mountain")
                {
                    travellingOnMountain = true;
                }
            }
        }
    }

    void CheckStatus()
    {
        //check if wagon is stopped or not

        if (viewBox.GetComponent<ViewboxController>().isMoving == false
            && hasStopped == false)
        {
            StartCoroutine(SlowDown());
        }

        else if (viewBox.GetComponent<ViewboxController>().isMoving == true)
        {
            hasStopped = false;
        }


        if (PlayerAgent.isStopped == true || hasStopped == true)
        {
            if (wagonSource.isPlaying == true)
            {
                wagonSource.Stop();
            }
        }

        if (PlayerAgent.isStopped == false && hasStopped == false)
        {
            if (wagonSource.isPlaying == false)
            {
                wagonSource.Play();
            }
        }

        SnowCondition();
        RepairCondition();
        //Debug.Log(wagonSource.isPlaying);
        //Debug.Log(wagonSource.clip);
    }

    private void SnowCondition()
    {
        if (travellingOnSnow == true)
        {
            if (PlayerAgent.speed == 2)
            {
                wagonSource.clip = wagonAudio[0];
            }

            else if (PlayerAgent.speed > 2)
            {
                wagonSource.clip = wagonAudio[1];
            }
        }
    }

    private void RepairCondition()
    {
        if (travellingOnMountain == true)
        {
            if (viewBox.GetComponent<RepairController>().gotEverything == true)
            {
                wagonSource.clip = wagonAudio[1];
            }

            else
            {
                wagonSource.clip = wagonAudio[0];
            }
        }
    }

    IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(1.2f);
        hasStopped = true;
    }
}