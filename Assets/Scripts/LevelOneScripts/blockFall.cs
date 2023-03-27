using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockFall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    
}
