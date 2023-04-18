using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DistortionEffect : ScriptableObject
{
    public abstract void apply(Collider2D effector);
}
