using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float _rotationSpeed = 180;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // rotate character with horizontal keys:
        float y = Input.GetAxis("Mouse Y") * Time.deltaTime * 90;
        float x = Input.GetAxis("Mouse X") * Time.deltaTime * 90;
        float moveY = Mathf.Clamp(y, -30, 30);
        float moveX = Mathf.Clamp(x, -30, 30);
        transform.Rotate(moveY, moveX, 0);

        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = Vector3.forward * Input.GetAxis("Vertical");
            // convert direction from local to global space:
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        // convert velocity to displacement and move character:
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
