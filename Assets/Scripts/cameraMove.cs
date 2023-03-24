using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject target; //used to determine the focal point for the camera
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector4(target.transform.position.x, target.transform.position.y, -10); //saves the camera position on the player
    }
}
