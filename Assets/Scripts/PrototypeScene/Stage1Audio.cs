using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stage1Audio : MonoBehaviour
{
    public NavMeshAgent PlayerAgent;
    public AudioClip[] wagonAudio;
    public AudioSource wagonSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAgent.isStopped == false)
        {
            if (wagonSource.isPlaying == false)
            {
                wagonSource.Play();
            }
        }
        Debug.Log(wagonSource.clip);
    }

    private void OnCollisionEnter (Collision other)
    {
        //if (other.gameObject.tag == "WoodenTerrain")
        //{
        //    Debug.Log("Travelling on wood");
        //    wagonSource.clip = wagonAudio[1];
        //}

        //else if (other.gameObject.tag == "RockyTerrain")
        //{
        //    Debug.Log("Travelling on rock");
        //    wagonSource.clip = wagonAudio[0];
        //}

        //else if (other.gameObject.tag == "Road")
        //{
        //    Debug.Log("Travelling on road");
        //    wagonSource.clip = wagonAudio[0];
        //}

        //else
        //{
        //    Debug.Log("Travelling on ground");
        //    wagonSource.clip = wagonAudio[0];
        //}

        foreach (AudioClip currentClip in wagonAudio)
        {
            if (other.gameObject.tag == currentClip.name)
            {
                wagonSource.clip = wagonAudio[System.Array.IndexOf(wagonAudio, currentClip)];
                Debug.Log("Travelling on " + currentClip.name);
            }
        }
    }
}