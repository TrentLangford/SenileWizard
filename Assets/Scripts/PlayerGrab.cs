using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public LayerMask InteractableMask;
    public float HoldDistance;
    public float HoldEpsilon;
    public float HoldForce;
    public float GrabDistance;
    public float ThrowForce;

    PlayerLook lookScript;
    Rigidbody heldBody;
    Vector3 holdPos;

    void Start()
    {
        lookScript = GetComponent<PlayerLook>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Fire();
    }

    // Probably doesnt need to be in lateupdate
    void LateUpdate()
    {
        holdPos = lookScript.CameraTransform.position + lookScript.CameraTransform.forward * HoldDistance;
        if (heldBody != null && Vector3.Distance(holdPos, heldBody.position) > HoldEpsilon)
        {
            heldBody.AddForce((holdPos - heldBody.position) * HoldForce);
        }
    }

    void Fire()
    {
        Ray interactRay = new Ray(lookScript.CameraTransform.position, lookScript.CameraTransform.forward);
        RaycastHit hitInfo;

        if (heldBody != null) EndGrab();
        else if (Physics.Raycast(interactRay, out hitInfo, GrabDistance, InteractableMask))
        {
            if (hitInfo.collider.CompareTag("Grab")) StartGrab(hitInfo.rigidbody);
        }
    }

    void StartGrab(Rigidbody body)
    {
        heldBody = body;
        heldBody.useGravity = false;
        heldBody.constraints = RigidbodyConstraints.FreezeRotation;
        heldBody.drag = 15f;
    }

    void EndGrab()
    {
        heldBody.useGravity = true;
        heldBody.constraints = RigidbodyConstraints.None;
        heldBody.drag = 1f;
        heldBody.AddForce(lookScript.CameraTransform.forward * ThrowForce);
        heldBody = null;
    }
}
