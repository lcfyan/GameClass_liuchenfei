using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public string targetSceneName;
    private bool hasCollided = false;
   

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("exit") && !hasCollided)
        {
            
            hasCollided = true;
           
            LoadScene(targetSceneName);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
