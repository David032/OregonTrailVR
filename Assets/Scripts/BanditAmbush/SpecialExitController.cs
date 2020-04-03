using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialExitController : MonoBehaviour
{
    public int desiredSceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(desiredSceneIndex);
    }
}
