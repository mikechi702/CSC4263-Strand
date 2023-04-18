using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDistort : MonoBehaviour
{
    [SerializeField]
    private GameObject pastCube, futureCube;
    [SerializeField]
    private GameObject wallDistFuture, wallDistPast, wallDistPastNode, playerObject;
    private Rigidbody2D playerBody;

    private SecondWallDistortion ExitEffect;

    private void Awake() {
        playerBody = playerObject.GetComponent<Rigidbody2D>();
        ExitEffect = new SecondWallDistortion(pastCube, futureCube, wallDistFuture, wallDistPast, wallDistPastNode, playerBody);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Pickup"))
            ExitEffect.apply(other);
    }
}
