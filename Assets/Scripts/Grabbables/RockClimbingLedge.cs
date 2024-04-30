using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockClimbingLedge : HandheldGizmo
{
    FixedJoint joint = null;
    public override bool DoAction()
    {
        // Should do nothing
        return true;
    }

    public override bool GrabEvent(GameObject hand)
    {
        if (joint != null) { 
        Destroy(joint);
        }
       joint =  hand.AddComponent<FixedJoint>();
        joint.connectedBody = GetComponent<Rigidbody>();
        return true;
    }

    public override bool ReleaseEvent(GameObject hand)
    {
        if (joint != null)
        {
            Destroy(joint);
        }
        return true;
    }

}
