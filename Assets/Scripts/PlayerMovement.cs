using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float MoveSpeed = 10f;
    //public float Gravity;

    Vector3 moveInput;
    Vector2 input;
    //float yVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        moveInput = transform.forward * input.y + transform.right * input.x;
        controller.Move(moveInput * MoveSpeed * Time.deltaTime);
    }
}
