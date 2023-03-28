using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (other.gameObject.CompareTag("Player"))
        {
            switch (currentScene.name) //Whenever new level is added, ADD IT TO THHE BUILD SETTINGS !!!
            {
                case ("SampleScene"):
                    StartCoroutine(LoadLevelAsync("EndScreen"));
                    break;
                case ("SampleScene2"):
                    StartCoroutine(LoadLevelAsync("TitleScreen"));
                    break;
            }
        }
    }

    IEnumerator LoadLevelAsync(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");

            yield return null;
        }
    }
}
