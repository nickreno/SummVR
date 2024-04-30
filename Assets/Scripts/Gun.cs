using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : HandheldGizmo
{
    [SerializeField] Transform bulletPoint;
    [SerializeField] GameObject bulletObject;
    [SerializeField] float gunCooldown;
    float gunTimer;

    private void Update()
    {
        gunTimer = Time.deltaTime;
    }
    public override bool DoAction()
    {
        if(gunTimer > gunCooldown)
        {
            gunTimer = 0;
            Instantiate(bulletObject, bulletPoint.position, Quaternion.LookRotation(bulletPoint.forward));
            return true;
        }
        return false;
    }
}
