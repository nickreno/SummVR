using Photon.Voice;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class PullInteraction : XRBaseInteractable
{
    // Start is called before the first frame update

    public static event Action<float> PullActionReleased;
    public Transform start, end;
    public GameObject notch;

    public float pullAmount { get; private set; } = 0.0f;

    private LineRenderer _lineRenderer;
    private IXRSelectInteractor pullingInteractor = null;
    private IXRSelectInteractor holdingInteractor = null;

    //Controllers
    public GameObject leftControllerGameObject;
    public GameObject rightControllerGameObject;

    private IXRSelectInteractor leftController;
    private IXRSelectInteractor rightController;

    private bool isInteracting = false;

    protected override void Awake()
    {
        base.Awake();
        _lineRenderer = GetComponent<LineRenderer>();

        //Get Controllers
        leftController = leftControllerGameObject.GetComponent<IXRSelectInteractor>();
        rightController = rightControllerGameObject.GetComponent<IXRSelectInteractor>();
    }


    public void SetPullInteractor(SelectEnterEventArgs args)
    {
        pullingInteractor = args.interactorObject;

        //Set Hold Controller
        SetHoldingInteractor();
    }

    public void SetHoldingInteractor(IXRSelectInteractor interactor)
    {
        holdingInteractor = interactor;
    }
    public void Release()
    {

        if (isInteracting)
        {
            PullActionReleased?.Invoke(pullAmount);
            releaseHaptic();
            pullingInteractor = null;
            pullAmount = 0f;
            notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, notch.transform.localPosition.y, 0f);
            UpdateString();
        }
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if(updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected)
            {
                Vector3 pullPosition = pullingInteractor.transform.position;
                pullAmount = CalculatePull(pullPosition);

                UpdateString();
                HapticFeedback();
            }
        }
    }

    private void HapticFeedback()
    {

        if(pullingInteractor != null)
        {
            ActionBasedController pullingController = pullingInteractor.transform.gameObject.GetComponent<ActionBasedController>();
            if(pullingController != null)
            {
                float intensity = pullAmount;
                float duration = 0.1f;
                pullingController.SendHapticImpulse(intensity, duration);
            }
        }
    }

    private float CalculatePull(Vector3 pullPosition)
    {
        Vector3 PullDirection = pullPosition - start.position;
        Vector3 targetDirection = end.position - start.position;
        float maxLength = targetDirection.magnitude;

        targetDirection.Normalize();
        float pullValue = Vector3.Dot(PullDirection, targetDirection) / maxLength;
        return Mathf.Clamp(pullValue, 0, 1);
    }

    private void UpdateString()
    {
        Vector3 linePosition = Vector3.forward * Mathf.Lerp(start.transform.localPosition.z, end.transform.localPosition.z, pullAmount);
        notch.transform.localPosition = new Vector3(notch.transform.localPosition.x, notch.transform.localPosition.y, linePosition.z + .2f);
        _lineRenderer.SetPosition(1,linePosition);
    }

    private void releaseHaptic()
    {
        if(pullingInteractor != null)
        {
            ActionBasedController holdingController = holdingInteractor.transform.GetComponent<ActionBasedController>();
            if(holdingController != null )
            {
                float intensity = 1.0f;
                float duration = 0.5f;
                holdingController.SendHapticImpulse(intensity, duration);
            }
        }
    }

    //Set Hold Controller
    private void SetHoldingInteractor()
    {
        // Check which controller is pulling and assign the other as holding
        if (pullingInteractor != null)
        {
            holdingInteractor = (pullingInteractor == leftController) ? rightController : leftController;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isInteracting = true;
    }
}
