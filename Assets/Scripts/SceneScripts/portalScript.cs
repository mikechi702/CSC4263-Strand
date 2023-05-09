using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public GameObject loadingScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (other.gameObject.CompareTag("Player"))
        {
            switch (currentScene.name) //Whenever new level is added, ADD IT TO THHE BUILD SETTINGS !!!
            {
                case ("SampleScene"):
                    StartCoroutine(LoadLevelAsync("SampleScene2"));
                    break;
                case ("SampleScene2"):
                    StartCoroutine(LoadLevelAsync("TitleScreen"));
                    break;
            }
        }
    }

    IEnumerator LoadLevelAsync(string scene)
    {
        loadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        Time.timeScale = 1;
        Slider progressBar = loadingScreen.transform.Find("RawImage").Find("Slider").gameObject.GetComponent<Slider>();

        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");
            progressBar.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            yield return null;
        }
    }
}
