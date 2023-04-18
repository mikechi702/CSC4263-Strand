using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaking : MonoBehaviour
{
    [SerializeField]
    private GameObject presentWall, futureWall;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("reversed"))
        {
            Debug.Log("Walls destroyed");
            Destroy(presentWall);
            Destroy(futureWall);
        }
    }
}
