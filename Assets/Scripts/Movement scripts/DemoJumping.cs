using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoJumping : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRigidBody; //the rigid body handling the physics
    [SerializeField]
    private float jumpSpeed; //a global variable that allows modification of the jumpspeed
    private bool isAirborne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && isAirborne == false) //the jump controls
            myRigidBody.velocity = Vector2.up * jumpSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) //used to detect if the player is on the ground, for jumping
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("fallingBlock"))
            isAirborne = false;
    }

    private void OnCollisionStay2D(Collision2D other) {
        if((other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("fallingBlock"))&& isAirborne == true)
            isAirborne = false;
    }

    private void OnCollisionExit2D(Collision2D other) //used to detect if the player is not jumping
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("fallingBlock"))
        {
            isAirborne = true;
        }
    }
}
