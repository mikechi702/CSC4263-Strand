using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame() {
        StartCoroutine(LoadSampleSceneAsync());
    }

    public void QuitGame() {
        Application.Quit();
    }

    IEnumerator LoadSampleSceneAsync() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");

        while (!asyncLoad.isDone) {
            Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");

            yield return null;
        }
    }
}
