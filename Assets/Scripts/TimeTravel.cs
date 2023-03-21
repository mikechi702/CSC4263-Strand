using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TimeTravel : MonoBehaviour
{
    [SerializeField]
    private GameObject userObject;

    private int timeSlots;
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
        //PSUEDOCODE FOR TIME TRAVEL SCRIPT

        // if(Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     Debug.Log("Time travel started");
        //     if(Input.GetKeyUp(KeyCode.Alpha1))
        //     {
        //         Debug.Log("Travelling to past");
        //     }
        //     else if(Input.GetKey(KeyCode.Alpha2))
        //     {
        //         Debug.Log("Travelling to Present");
        //     }
        //     else if(Input.GetKey(KeyCode.Alpha3))
        //     {
        //         Debug.Log("Travelling to Future");
        //     }
        // }

        
    }

    private void TimeSlotLeap(InputAction.CallbackContext timeContext)
    {
        Debug.Log("Time travel initiated");
    }

}
