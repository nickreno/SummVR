using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class HandheldGizmo : MonoBehaviour
{
    public abstract bool DoAction();

    public virtual bool GrabEvent(GameObject hand)
    {
        // Overide this in future implementations
        // By default this should have no action, so return false
        // For an example of this being used, check out RockClimbingLedge.cs
        return false;
    }

    public virtual bool ReleaseEvent(GameObject hand) {
        // Overide this in future implementations
        // By default this should have no action, so return false
        return false; 
    }

}
