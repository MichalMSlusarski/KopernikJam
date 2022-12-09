using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera camera; // The orthographic camera to control

    private Transform target; // The target to center the camera on

    public float smoothTime = 0.3f; // The time it takes for the camera to smoothly move to the target
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // If the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            // Perform a raycast to find the first object hit by the ray
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Set the target to the object hit by the ray
                target = hit.transform;
            }
        }

        // If there is a target, smoothly move the camera to the target position
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}

