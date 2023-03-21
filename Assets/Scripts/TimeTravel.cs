using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    [SerializeField]
    private GameObject userObject;

    private int numTimeSlots;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PSUEDOCODE FOR TIME TRAVEL SCRIPT

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
        //    if( Input.GetKeyDown(any num key)  )
            Debug.Log("Time travel started");
        }

        
    }
    // used for time travel script
    // void OnGUI() 
    // {
    //     if(Event.current.Equals(Event.KeyboardEvent(KeyCode.LeftShift.ToString())))
    //     {
    //         Debug.Log("Time travel mechanic initiated");
    //     }
    // }

}
