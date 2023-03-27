using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetScene : MonoBehaviour
{
    private Scene currentScene;
    private bool resetting = false;
    private float startTime;

    private void Awake() {
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
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Reset scene state initialized");
            resetting = true;
            startTime = Time.time;
        }
        if(Input.GetKeyDown(KeyCode.L) && resetting == true)
        {
            SceneManager.LoadScene(currentScene.name); //resets the level just in case...
            Debug.Log("Scene reset");
        }

        if(Time.time - startTime > 3.0) //aborts time travel if 3 seconds have passed
        {
                resetting = false;
                Debug.Log("Scene reset aborted");
        }
    }
}
