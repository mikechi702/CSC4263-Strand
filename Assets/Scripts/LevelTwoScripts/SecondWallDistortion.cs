using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "puzzleParts/SecondWallDistortion")]

public class SecondWallDistortion : DistortionEffect
{
    [SerializeField]
    private GameObject pastCube, futureCube;
    [SerializeField]
    private GameObject wallDistFuture, wallDistPast, wallDistPastNode;
    [SerializeField]
    private Rigidbody2D playerBody;

    public SecondWallDistortion(GameObject pC, GameObject fC, GameObject wDF, GameObject wDP, GameObject wDPN, Rigidbody2D rb)
    {
        pastCube = pC;
        futureCube = fC;
        wallDistFuture = wDF;
        wallDistPast = wDP;
        wallDistPastNode = wDPN;
        playerBody = rb;
    }
    public override void apply(Collider2D effector)
    {
        Debug.Log("Cube positions distorting again!");
        pastCube.transform.position = wallDistPastNode.transform.position;
    //    playerBody.gravityScale = -1.0f;
        Destroy(wallDistFuture);
        Destroy(wallDistPast);
    }
}
