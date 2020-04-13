using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject startButton;
    public float loadTime = 2f;
    public Light lookingAtIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == startButton)
        {
            lookingAtIndicator.gameObject.SetActive(true);
            StartCoroutine(MenuCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == startButton)
        {
            lookingAtIndicator.gameObject.SetActive(false);
            StopCoroutine(MenuCountdown());
        }
    }

    IEnumerator MenuCountdown() 
    {
        yield return new WaitForSeconds(loadTime/2);
        print("Halfway to load");
        yield return new WaitForSeconds(loadTime/2);
        SceneManager.LoadScene(1);
    }
}
