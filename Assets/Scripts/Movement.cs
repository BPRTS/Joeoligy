using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public Transform cam;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Get the forward and right directions of the camera
            Vector3 camForward = cam.transform.forward;
            Vector3 camRight = cam.transform.right;

            // Make sure they're horizontal
            camForward.y = 0f;
            camRight.y = 0f;

            // Normalize them
            camForward.Normalize();
            camRight.Normalize();

            // Calculate the move direction relative to the camera
            Vector3 moveDirection = (camForward * vertical + camRight * horizontal).normalized;

            // Move the player
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
    }
}
