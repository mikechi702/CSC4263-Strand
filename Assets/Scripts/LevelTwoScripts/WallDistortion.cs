using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDistortion : MonoBehaviour
{
    [SerializeField]
    private GameObject presentCube, futureCube;
    [SerializeField]
    private GameObject wallDistPres, wallDistPresNode, wallDistFut;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Pickup")) //puts the present cube above the cracked wall when future cube is above cracked wall
        {
            Debug.Log("Cube positions distorting!");
            presentCube.transform.position = wallDistPresNode.transform.position;
            Destroy(wallDistFut);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
