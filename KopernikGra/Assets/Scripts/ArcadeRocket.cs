using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeRocket : MonoBehaviour
{
    // The speed at which the rocket will move
    public float speed = 10.0f;

    // The rate at which the rocket's thrust will regenerate
    public float thrustRegenRate = 0.5f;

    // The maximum amount of thrust that the rocket can have
    public float maxThrust = 100.0f;

    // The current amount of thrust that the rocket has
    private float currentThrust = 0.0f;

    // The rigidbody component of the rocket
    private Rigidbody2D rb;

    [SerializeField] GameObject thruster;

    void Start()
    {
        // Get the rigidbody component of the rocket
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            // Check if the rocket has enough thrust to move
            if (currentThrust > 0)
            {
                thruster.SetActive(true);
                
                // Get the position of the mouse in world space
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Calculate the direction to move in
                Vector2 direction = (Vector2)(mousePos - transform.position);
                

                // Normalize the direction so that the rocket moves at a constant speed
                direction.Normalize();
                
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Rotate the rocket to face the direction of the mouse cursor
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                // Move the rocket in the specified direction
                rb.velocity = direction * speed;

                // Decrease the rocket's thrust
                currentThrust -= Time.deltaTime;
            }
        }
        else
        {
            thruster.SetActive(false);
            // If the left mouse button is not held down, regenerate the rocket's thrust
            currentThrust += Time.deltaTime * thrustRegenRate;
            currentThrust = Mathf.Clamp(currentThrust, 0, maxThrust);
        }
    }
}

