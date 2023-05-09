using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pause;
    public GameObject loadingScreen;
    private Scene currentScene;

    public void StartGame() {
        StartCoroutine(LoadSceneAsync("SampleScene"));
    }

    public void LevelSelect() {
        StartCoroutine(LoadSceneAsync("LevelSelect"));
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
        loadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        Time.timeScale = 1;
        Slider progressBar = loadingScreen.transform.Find("RawImage").Find("Slider").gameObject.GetComponent<Slider>();

        while (!asyncLoad.isDone) {
            Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");
            progressBar.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            yield return null;
        }
    }
}
