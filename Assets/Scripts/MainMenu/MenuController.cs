using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject startButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == startButton)
        {
            StartCoroutine(MenuCountdown());
        }
    }

    IEnumerator MenuCountdown() 
    {
        yield return new WaitForSeconds(2.5f);
        print("Halfway to load");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }
}
