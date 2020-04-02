using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public int sceneIndexToLoad;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<OVRHand>())
        {
            print("Oi! I just got punched!");
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
}
