using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class Network_Player_SVR_VERSION2 : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private PhotonView photonView;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    public Transform leftHandPhysics;
    public Transform rightHandPhysics;

    private Transform leftHandPhysicsRig;
    private Transform rightHandPhysicsRig;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    bool initalized = false;

    private void Start()
    {
        Invoke("Initialize", 1);
    }

    public void Initialize()
    {
        initalized = true;
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        //tutorial says use XRRig, but Unity tells me to use XROrigin instead since XRRig is obselete.

        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/Left Controller");
        rightHandRig = rig.transform.Find("Camera Offset/Right Controller");

        leftHandPhysicsRig = rig.transform.Find("Left Hand Physics");
        rightHandPhysicsRig = rig.transform.Find("Right Hand Physics");

        //the quotes above are the EXACT name and path for the cam offset and components from the XR RIG.
        //DO NOT CHANGE THEIR NAMES IN THE EDITOR

        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }

    private void Update()
    {
        if ( !initalized)
        {
            return;
        }
        if (photonView.IsMine)
        {
            Debug.Log("this is me");

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);

            MapPosition(leftHandPhysics, leftHandPhysicsRig);
            MapPosition(rightHandPhysics, rightHandPhysicsRig);

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
        }

    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        target.SetPositionAndRotation(rigTransform.position, rigTransform.rotation);
    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    
}
