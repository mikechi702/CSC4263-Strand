using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedScript : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D seedRb; //rigidbody for the seed physics
    [SerializeField]
    private GameObject seedObj; //gameobject of the seed
    [SerializeField]
    private GameObject sapling; //gameobject of the sapling in the present
    [SerializeField]
    private GameObject tree; //gameobject of the fully-grown tree in the future
    private bool unearthed = false; //determines if the seed was found with the falling block
    [SerializeField]
    private float transformDist = 1; //modify how the seed spawns in

    private void Awake() {
        sapling.SetActive(false);
        tree.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(!unearthed)
        {
            if(other.gameObject.CompareTag("fallingBlock")) //dislodges the seed from the ground so player can pick up
            {
                unearthed = true;
                seedRb.bodyType = RigidbodyType2D.Dynamic;
                transform.position += new Vector3(0, transformDist, 0);
            }
        }
        else
        {
            if(other.gameObject.CompareTag("fertileSoil")) //destroys the seed object and grows the sapling and tree when it is 'planted'
            {
                Destroy(seedObj);
                sapling.SetActive(true);
                tree.SetActive(true);
            }
        }
    }
}
