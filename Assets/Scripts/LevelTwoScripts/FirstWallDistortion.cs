using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "puzzleParts/FirstWallDistortion")]

public class FirstWallDistortion : DistortionEffect
{
    [SerializeField]
    private GameObject presentCube, futureCube;
    [SerializeField]
    private GameObject wallDistPres, wallDistPresNode, wallDistFut;

    public FirstWallDistortion(GameObject pC, GameObject fC, GameObject wDP, GameObject wDPN, GameObject wDF)
    {
        presentCube = pC;
        futureCube = fC;
        wallDistPres = wDP;
        wallDistPresNode = wDPN;
        wallDistFut = wDF;
    }

    public override void apply(Collider2D effector)
    {
        Debug.Log("Cube positions distorting!");
        presentCube.transform.position = wallDistPresNode.transform.position;
        Destroy(wallDistFut);
    }
}
