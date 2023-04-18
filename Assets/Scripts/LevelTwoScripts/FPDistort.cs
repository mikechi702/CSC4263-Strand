using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPDistort : MonoBehaviour
{
    [SerializeField]
    private GameObject presentCube, futureCube;
    [SerializeField]
    private GameObject wallDistPres, wallDistPresNode, wallDistFut;
    private FirstWallDistortion FPEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Pickup"))
            FPEffect.apply(other);
    }

    private void Awake()
    {
        FPEffect = new FirstWallDistortion(presentCube, futureCube, wallDistPres, wallDistPresNode, wallDistFut);
    }
}
