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

    public void LevelSelect() {
        StartCoroutine(LoadSceneAsync("LevelSelect"));
    }

    public void SelectLevel2() {
        StartCoroutine(LoadSceneAsync("SampleScene2"));
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Application exited");
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        Debug.Log("Application paused");
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pause.SetActive(true);
        Cursor.visible = false;
    }

    public void RestartLevel() {
        Debug.Log("Restart level");
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
