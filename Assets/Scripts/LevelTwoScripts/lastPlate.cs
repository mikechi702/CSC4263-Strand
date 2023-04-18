using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastPlate : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Rigidbody2D playerBody;
    private void Awake(){
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("BigBlock"))
        {
            playerBody.gravityScale = -1.0f;
            player.transform.rotation = new Quaternion(-180.0f, 0.0f, -180.0f, 1);
            Debug.Log("Player's gravity is reversed!");
        }
    }
}
