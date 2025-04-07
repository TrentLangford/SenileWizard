using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float Sensitivity;
    public Transform CameraTransform;
    float xRotation;
    Vector2 input;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Mouse X");
        input.y = Input.GetAxisRaw("Mouse Y");
        input *= Sensitivity;

        transform.Rotate(transform.up * input.x);

        xRotation -= input.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        CameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
