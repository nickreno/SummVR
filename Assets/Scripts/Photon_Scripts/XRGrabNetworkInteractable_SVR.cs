using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRGrabNetworkInteractable_SVR : XRGrabInteractable
{
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }


    //below was OnSelectEnter in the tutorial. DNE, so options were OnSelectedEntered and OnSelectedEntering.
    //FIXME this is potentially an issue. Game object (cube) parent is not clear until one person
    //      un-grabs the object, relinquishing their ownership.
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        photonView.RequestOwnership();
        base.OnSelectEntered(interactor);
    }
}
