using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolve : MonoBehaviour
{
    // The object that we want to orbit around
    public Transform orbitTarget;

    // The speed at which we want the object to orbit
    public float orbitSpeed = 5f;

    // The radius of the orbit
    public float orbitRadius = 5f;

    // The current angle of the orbit
    private float orbitAngle = 0f;

    void Update()
    {
        // Update the orbit angle
        orbitAngle += orbitSpeed * Time.deltaTime;

        // Calculate the new position for the orbiting object
        float x = Mathf.Cos(orbitAngle) * orbitRadius;
        float y = Mathf.Sin(orbitAngle) * orbitRadius;
        Vector3 orbitPosition = new Vector3(x, y, 0);

        // Set the position of the orbiting object
        transform.position = orbitPosition + orbitTarget.position;
    }
}
