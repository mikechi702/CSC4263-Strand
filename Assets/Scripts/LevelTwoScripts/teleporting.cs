using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporting : MonoBehaviour
{
    [SerializeField]
    private GameObject dest;
    [SerializeField]
    private GameObject user;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = dest.transform.position; //teleports the player to another destination
            Debug.Log("Teleportation successful");
        }

    }
    
}
