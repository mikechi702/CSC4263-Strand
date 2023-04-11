using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(other.gameObject.CompareTag("Player"))
        {
            switch(currentScene.name) //Whenever new level is added, ADD IT TO THHE BUILD SETTINGS !!!
            {
                case("SampleScene"):
                    SceneManager.LoadScene("EndScreen");
                    break;
                case("SampleScene2"):
                    SceneManager.LoadScene("TitleScreen");
                    break;
            }
        }
    }
}
