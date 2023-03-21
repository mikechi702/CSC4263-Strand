using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupScript : MonoBehaviour
{
    [SerializeField]
    private Transform pickupDetect;
    [SerializeField]
    private Transform objHolder;
    [SerializeField]
    private float rayDist;
    private bool isHolding = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D isGrabbed = Physics2D.Raycast(pickupDetect.position, Vector2.right * transform.localScale, rayDist);

        if(isGrabbed.collider != null && isGrabbed.collider.tag == "Pickup")
        {
            if(Input.GetKey(KeyCode.E) && isHolding == false)
            {
                isGrabbed.collider.gameObject.transform.parent = objHolder;
                isGrabbed.collider.gameObject.transform.position = objHolder.position;
                isGrabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                isHolding = true;
            }
            else if(Input.GetKey(KeyCode.E) && isHolding == true)
            {
                isGrabbed.collider.gameObject.transform.parent = null;
                isGrabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                isHolding = false;
            }
        }
    }
}
