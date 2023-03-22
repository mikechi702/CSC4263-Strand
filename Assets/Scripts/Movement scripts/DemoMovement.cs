using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D demoBody;

    [SerializeField]
    private float roverSpeed;

    private float moving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moving = Input.GetAxis("Horizontal");
        demoBody.velocity = new Vector2(roverSpeed * moving, demoBody.velocity.y);
    }
}
