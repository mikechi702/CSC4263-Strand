using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
    private enum limits
    {
        noLimit = 0, limit30 = 30, limit60 = 60, limit120 = 120, limit244 = 244,
    }

    [SerializeField]
    private limits limit;
    private void Awake() {
        Application.targetFrameRate = (int)limit;
    }
}
