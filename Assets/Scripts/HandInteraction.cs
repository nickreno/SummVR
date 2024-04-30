using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandInteraction : MonoBehaviour
{
    public HandheldGizmo gizmoInUse;
    public GameObject physicsHand;

    public InputActionReference trigger;

    private void OnEnable()
    {
        trigger.ToInputAction().performed += UseTheGizmo;
    }
    public void UseTheGizmo(InputAction.CallbackContext context)
    {
        gizmoInUse?.DoAction();
    }

    public void AssignInteraction(SelectEnterEventArgs args)
    {
        gizmoInUse = args.interactableObject.transform.gameObject.GetComponent<HandheldGizmo>();
        gizmoInUse?.GrabEvent(physicsHand);
    }
    public void ReleaseGrab(SelectExitEventArgs args)
    {
        gizmoInUse?.ReleaseEvent(physicsHand);
        gizmoInUse = null;
    }

}
