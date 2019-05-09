using System;
using UnityEngine;

public abstract class IInteractiveObject : MonoBehaviour
{
    public abstract void OnGaze(bool animationTrigger);
}