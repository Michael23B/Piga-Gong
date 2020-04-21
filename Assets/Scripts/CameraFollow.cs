using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerObject;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float mouseSensitivity = 0.5f;

    void FixedUpdate()
    {
        var playerTransform = playerObject.transform;
        var controllerTransform = transform;
        var controllerRotation = controllerTransform.rotation;

        // Follow Target
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(controllerTransform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Mouse Rotation Handler
        // controllerTransform.Rotate( Input.GetAxis("Mouse Y"),Input.GetAxis("Mouse X"),0f);

        var yaw = Quaternion.Euler(0f, Input.GetAxis("Mouse X") * mouseSensitivity, 0f);
        var pitch = Quaternion.Euler(-Input.GetAxis("Mouse Y") * mouseSensitivity, 0f, 0f);
        transform.rotation =  yaw * controllerRotation * pitch; // yaw on the left && pitch on the right?
        
        // Copy Rotation
        playerTransform.transform.rotation = controllerRotation;
        
        
    }
}
