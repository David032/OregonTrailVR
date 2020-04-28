using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HorseAudio : MonoBehaviour
{
    public NavMeshAgent PlayerAgent;
    public AudioClip[] horseAudio;
    public AudioSource horseAudioSource;
    private bool horseIsNeighing;
    public GameObject playerWagon;

    void Start()
    {
        horseIsNeighing = false;
    }

    void Update()
    {
      if (PlayerAgent.speed > 2 && horseIsNeighing == false)
      {
            StartCoroutine(Neigh());
      }
    }

    IEnumerator Neigh()
    {
        float waitingFor; 

        if (playerWagon.GetComponent<StageAudio>().hasStopped == false)
        {
            waitingFor = Random.Range(3.0f, 6.5f);
        }

        else
        {
            waitingFor = Random.Range(7.0f, 13.0f);
        }

        int pickNeigh = Random.Range(0, 5);
        horseAudioSource.clip = horseAudio[pickNeigh];
        horseAudioSource.Play();
        horseIsNeighing = true;
        yield return new WaitForSeconds(horseAudioSource.clip.length + waitingFor);
        horseIsNeighing = false;
    }
}