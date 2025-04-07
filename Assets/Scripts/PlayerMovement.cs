using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float MoveSpeed = 10f;
    Vector3 moveInput;
    Vector2 input;

    void Start()
    {
        
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        input.Normalize();

        moveInput = transform.forward * input.y + transform.right * input.x;
        controller.Move(moveInput * MoveSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
    }
}
