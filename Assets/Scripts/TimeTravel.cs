using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TimeTravel : MonoBehaviour
{
    [SerializeField]
    private GameObject userObject;

    private int timeSlots;
    private float startTime;
    private bool isTravelling = false;
    private InputAction timeLeap;

    private TimeTravelling timeTravel;

    private void Awake() 
    {
        timeTravel = new TimeTravelling();
    }

    private void OnEnable() 
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
            if(Input.GetKey(KeyCode.Alpha1)) //turn this into a switch statement at some point for optimization
            {
                Debug.Log("Travelling to the past");
                isTravelling = false;
            }
            else if(Input.GetKey(KeyCode.Alpha2))
            {
                Debug.Log("Travelling to the present");
                isTravelling = false;
            }
            else if(Input.GetKey(KeyCode.Alpha3))
            {
                Debug.Log("Travelling to the future");
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
        startTime = Time.time; //logs the time
        Debug.Log("Time travel initiated");
        isTravelling = true;

    }

}
