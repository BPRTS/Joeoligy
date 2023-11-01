using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float smooth = 5.0f;
    public float radius = 2.0f; // Set the desired offset here
    public float heightOffset = 1.0f; // Set the desired height offset here
    public float rotationSpeed = 5.0f; // Set the desired rotation speed here

    private float mouseX, mouseY;
    private bool isRotating = false;
    private Vector3 cameraPosition;

    void Update()
    {
        Vector3 movePos = target.position - (target.forward * radius);
        movePos.y += heightOffset; // Add the height offset here
        movePos = Vector3.MoveTowards(movePos, transform.position, Time.deltaTime * smooth);
        transform.position = movePos;



        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
            //cameraPosition = transform.position;
            //transform.LookAt(target);
        }

        if (isRotating)
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(target);
            transform.RotateAround(target.position, Vector3.up, mouseX);
            transform.RotateAround(target.position, transform.right, mouseY);
        }


    }

    void LateUpdate()
    {
        if (!isRotating)
        {
            //transform.position = cameraPosition;
            transform.LookAt(target);
            transform.RotateAround(target.position, Vector3.up, mouseX);
            transform.RotateAround(target.position, transform.right, mouseY);
        }
    }
}