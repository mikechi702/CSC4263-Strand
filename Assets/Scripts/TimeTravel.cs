using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;
public class TimeTravel : MonoBehaviour
{
    [SerializeField]
    private GameObject userObject; //The player object being time travelled
    private string currentTime; //the timeslot the player is currently in
    private float startTime; //The time recorded when the time travel controls (Shift) starts.
    private Vector3 currentPos; //Position of the player in current timeslot when time travel is executed
    private InputAction timeLeap; //inputactions that enables the timeLeap state

    private TimeTravelling timeTravel; //awakens the time travel object.

    AudioSource source;
    public VisualEffect effect;


    private void OnEnable() //execution of the time travel mechanic.
    {
        timeLeap = timeTravel.Player.TimeSlotLeap;
        timeLeap.Enable();
        timeLeap.performed += TimeSlotLeap;
    }

    private void OnDisable() 
    {
        timeLeap.Disable();
    }

    private Vector3[] playerPos = {Vector3.zero, Vector3.zero, Vector3.zero}; //array containing all the player positions during time travel.
    private bool isTravelling = false; //boolean used to determine if the player is within the timeLeap state
    [SerializeField]
    private GameObject pastSpawn; //the initial spawn locations in past and future the player will go to on first time travel
    [SerializeField]
    private GameObject futureSpawn;
    [SerializeField]
    private Material timeShader;

    private void Awake() //called at the beginning of the scene i think
    {
        timeTravel = new TimeTravelling();
        currentTime = "Present";
        timeShader.SetColor("_Color", Color.yellow * 25);
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isTravelling)
        {

            //play sound and effect
            source.Play();
            effect.Play();

            if(Input.GetKey(KeyCode.Alpha1) && !currentTime.Equals("Past"))
            {
                Debug.Log("Travelling to the past");
                positionSet(userObject.transform.position);
                currentTime = "Past";
                timeShader.SetColor("_Color", Color.green * 25);

                if(playerPos[0].Equals(Vector3.zero))
                {
                    Debug.Log("First time past teleport");
                    userObject.transform.position = pastSpawn.transform.position;
                }
                else
                {
                    Debug.Log("Subsequent past teleports");
                    userObject.transform.position = playerPos[0];
                }

                isTravelling = false;
            }
            else if(Input.GetKey(KeyCode.Alpha2) && !currentTime.Equals("Present"))
            {
                Debug.Log("Travelling to the present");
                positionSet(userObject.transform.position);
                currentTime = "Present";
                timeShader.SetColor("_Color", Color.yellow * 25);

                Debug.Log("Subsequent present teleports");
                userObject.transform.position = playerPos[1];
                
                isTravelling = false;
            }
            else if(Input.GetKey(KeyCode.Alpha3) && !currentTime.Equals("Future"))
            {
                Debug.Log("Travelling to the future");
                positionSet(userObject.transform.position);
                currentTime = "Future";
                timeShader.SetColor("_Color", new Color(143, 0, 254, 1)); //purple

                if(playerPos[2].Equals(Vector3.zero))
                {
                    Debug.Log("First time future teleport");
                    userObject.transform.position = futureSpawn.transform.position;
                }
                else
                {
                    Debug.Log("Subsequent future teleports");
                    userObject.transform.position = playerPos[2];
                }

                isTravelling = false;
            }

            if(Time.time - startTime > 3.0) //aborts time travel if 3 seconds have passed
            {
                isTravelling = false;
                Debug.Log("Time travel function stopped");
            }
        }
    }

    private void TimeSlotLeap(InputAction.CallbackContext timeContext) //logic that starts the time travel state FSM
    {
        startTime = Time.time; //logs the time to measure
        Debug.Log("Time travel initiated");
        currentPos = userObject.transform.position; //logs the position 
        isTravelling = true;
    }

    private void positionSet(Vector3 position) //logs the previous timeslots position upon player time travel
    {
        switch(currentTime)
        {
            case "Past":
                playerPos[0] = position;
                break;
            case "Present":
                playerPos[1] = position;
                break;
            case "Future":
                playerPos[2] = position;
                break;
        }

    }

}
