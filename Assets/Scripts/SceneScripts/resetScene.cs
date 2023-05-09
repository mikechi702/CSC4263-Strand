using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetScene : MonoBehaviour
{
    public GameObject loadingScreen;
    private Scene currentScene;
    private bool resetting = false;
    private float startTime;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        resetting = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Reset scene state initialized");
            resetting = true;
            startTime = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("Reset scene state stopped");
            resetting = false;
        }
        if (Input.GetKeyDown(KeyCode.L) && resetting == true)
        {
            StartCoroutine(LoadLevelAsync(currentScene.name)); //resets the level just in case...
            Debug.Log("Scene reset");
        }

        if (Time.time - startTime > 3.0) //aborts time travel if 3 seconds have passed
        {
            resetting = false;
            Debug.Log("Scene reset aborted");
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
