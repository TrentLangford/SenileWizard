using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask InteractableMask;
    public float UseDistance;

    PlayerLook lookScript;
    void Start()
    {
        lookScript = GetComponent<PlayerLook>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2")) Fire();
    }

    void Fire()
    {
        Ray interactRay = new Ray(lookScript.CameraTransform.position, lookScript.CameraTransform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(interactRay, out hitInfo, UseDistance, InteractableMask))
        {
            if (hitInfo.collider.CompareTag("Use")) hitInfo.collider.GetComponent<Usable>().Use();
        }
    }
}
