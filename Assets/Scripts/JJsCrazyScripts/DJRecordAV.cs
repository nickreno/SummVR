using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;


public class DJRecordAV : MonoBehaviour

{
    public InputActionReference rAngularVel;
    AudioSource recordSource;
    Vector3 vrhandPos;
    Vector3 vlhandPos;
    Vector3 recordRotation;
    Quaternion oRotation;
    Quaternion rotationPre;
    Vector3 angularRightHand, velocityRightHand;
    public float speed = 1;
    public bool spManip;
    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
        GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
        recordSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        //if (spManip == false)
        //{
        //    gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.up * speed;
        //    recordSource.pitch = speed;
        //}

        angularRightHand = rAngularVel.action.ReadValue<Vector3>();
        float testSpeed = Vector3.SqrMagnitude(angularRightHand);
        if (angularRightHand.x >= 0)
        {
            transform.Rotate(Vector3.up * -testSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up * testSpeed * Time.deltaTime);
        }

    }
    private void Update()
    {
       // vrhandPos = rHandPos.action.ReadValue<Vector3>();
       // vlhandPos = lHandPos.action.ReadValue<Vector3>();
       //angularRightHand = rAngularVel.action.ReadValue<Vector3>();
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Hands")
    //    {
    //        oRotation = transform.rotation;
    //    }
    //}


    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Hands")
    //    {
    //        recordRotation = transform.eulerAngles;
    //        rotationPre = transform.rotation;
    //        spManip = true;
    //        float rangle = Mathf.Atan2(vrhandPos.z, vrhandPos.x) * Mathf.Rad2Deg;
    //        float langle = Mathf.Atan2(vlhandPos.z, vlhandPos.x) * Mathf.Rad2Deg;
    //        if (other.gameObject.name == "Right Controller" && gameObject.name == "diskRight")
    //        {
    //            transform.rotation = oRotation * Quaternion.AngleAxis(rangle + 120, Vector3.up);
    //        }
    //        else if (other.gameObject.name == "Left Controller" && gameObject.name == "diskLeft")
    //        {
    //            transform.rotation = oRotation * Quaternion.AngleAxis(langle + 120, Vector3.up);
    //        }
    //        deltaAngle = Quaternion.Angle(rotationPre, transform.rotation);
    //        if (transform.eulerAngles.y < recordRotation.y || Mathf.Sign(speed) == -1)
    //        {
    //            deltaAngle = deltaAngle * -1;
    //        }
    //        if (transform.eulerAngles.y - recordRotation.y < 0.01 && transform.eulerAngles.y - recordRotation.y > -1.2)
    //        {
    //            deltaAngle = 0;
    //        }
    //        recordSource.pitch = deltaAngle;
    //    }
    //}
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Hands")
    //    {
    //        spManip = false;
    //        recordSource.pitch = 1;
    //    }
    //}
}