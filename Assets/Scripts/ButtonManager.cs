using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pause;
    private Scene currentScene;

    public void StartGame() {
        StartCoroutine(LoadSceneAsync("SampleScene"));
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void PauseGame() {
        Time.timeScale = 0;
        gameObject.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
        pause.SetActive(true);
    }

    public void RestartLevel() {
        currentScene = SceneManager.GetActiveScene();
        StartCoroutine(LoadSceneAsync(currentScene.name));
    }

    public void QuitLevel() {
        StartCoroutine(LoadSceneAsync("TitleScreen"));
    }

    IEnumerator LoadSceneAsync(string scene) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        Time.timeScale = 1;

        while (!asyncLoad.isDone) {
            Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");

            yield return null;
        }
    }
}
