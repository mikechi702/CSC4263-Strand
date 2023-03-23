using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TimeTravel : MonoBehaviour
{
    [SerializeField]
    private GameObject userObject; //The player object being time travelled
    private string currentTime; //the timeslot the player is currently in
    private float startTime; //The time recorded when the time travel controls (Shift) starts.
    private Vector2 currentPos; //Position of the player in current timeslot when time travel is executed
    private Vector2[] playerPos = new Vector2[3]; //array containing all the player positions during time travel.
    private bool isTravelling = false; //boolean used to determine if the player is within the timeLeap state
    private InputAction timeLeap; //inputactions that enables the timeLeap state

    private TimeTravelling timeTravel; //awakens the time travel object.

    private void Awake() //called at the beginning of the scene i think
    {
        timeTravel = new TimeTravelling();
        currentTime = "Present";
    }

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

    // Update is called once per frame
    void Update()
    {
        if(isTravelling)
        {
            if(Input.GetKey(KeyCode.Alpha1) && !currentTime.Equals("Past")) //turn this into a switch statement at some point for optimization
            {
                Debug.Log("Travelling to the past");
                currentTime = "Past";
                isTravelling = false;
            }
            else if(Input.GetKey(KeyCode.Alpha2) && !currentTime.Equals("Present"))
            {
                Debug.Log("Travelling to the present");
                currentTime = "Present";
                isTravelling = false;
            }
            else if(Input.GetKey(KeyCode.Alpha3) && !currentTime.Equals("Future"))
            {
                Debug.Log("Travelling to the future");
                currentTime = "Future";
                isTravelling = false;
            }

            if(Time.time - startTime > 3.0) //aborts time travel if 3 seconds have passed
            {
                isTravelling = false;
                Debug.Log("Time travel function stopped");
            }
        }
    }

    private void TimeSlotLeap(InputAction.CallbackContext timeContext)
    {
        startTime = Time.time; //logs the time to measure
        Debug.Log("Time travel initiated");
        isTravelling = true;
    }

}
