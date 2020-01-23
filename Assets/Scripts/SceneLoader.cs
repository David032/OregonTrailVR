using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneIndexToLoad;
    public bool autoCalculateIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (autoCalculateIndex)
        {
            sceneIndexToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
