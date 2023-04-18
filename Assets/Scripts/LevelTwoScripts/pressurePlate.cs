using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    [SerializeField]
    private GameObject plate; //pressure plate gameobject
    [SerializeField]
    private float pressWeight = -0.1f; //speed which the pressure plate presses
    private Vector3 initialPos; //starting point of the pressure plate
    private bool moveUp = false; //determines if pressure plate needs to move back up
    private float startTime, gravTime; //time buffer if pressure plate moves up
    [SerializeField]
    private GameObject pastCube, presentCube, futureCube; //the cubes that spawn when pressure plate is down
    private Rigidbody2D presCubeRb;
    private bool wasReversed = false;

    public pressurePlate()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(plate.name == "PastPlate")
        {
            if(other.gameObject.CompareTag("Player"))
            {
                moveUp = false;
                //plate.GetComponent<SpriteRenderer>().color = Color.red;
                Debug.Log("Standing on plate");

                pastCube.SetActive(true);
                presentCube.SetActive(true);
                futureCube.SetActive(true);

            }
        }
        else if(plate.name == "PresentPlateGrav")
        {
            if(other.gameObject.CompareTag("Player"))
            {
                //plate.GetComponent<SpriteRenderer>().color = Color.red;
                Debug.Log("Standing on plate");
                if(presentCube.activeSelf)
                {
                    presCubeRb.gravityScale = -1.0f; //reverses gravity when player steps on this plate.
                }
                else
                    Debug.Log("Present cube not spawned!");
                moveUp = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //plate.GetComponent<SpriteRenderer>().color = Color.green;
            Debug.Log("Stepping off plate");
            if(presentCube.activeSelf)
            {
                if(plate.name == "PresentPlateGrav")
                {
                    gravTime = Time.time;
                    wasReversed = true;
                }
            }
            startTime = Time.time;
            moveUp = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            plate.transform.Translate(0,pressWeight,0);
        //    Debug.Log("Sitting on plate");
        }
    }

    public bool getReversed()
    {
        return wasReversed;
    }
    private void Awake() {
        presCubeRb = presentCube.GetComponent<Rigidbody2D>();

        pastCube.SetActive(false);
        presentCube.SetActive(false);
        futureCube.SetActive(false);        
    }
    void Start()
    {
        initialPos = transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        if(moveUp)
        {
            if(transform.position.y < initialPos.y && Time.time - startTime > 3.0f)
                transform.Translate(0, -pressWeight, 0);
            else if(transform.position.y >= initialPos.y)
                moveUp = false;
        }

        if(wasReversed)
        {
            if(Time.time - gravTime > 3.0f)
            {
                presCubeRb.gravityScale = 1.0f;
                presentCube.tag = "reversed";
            }
        }
    }
}
