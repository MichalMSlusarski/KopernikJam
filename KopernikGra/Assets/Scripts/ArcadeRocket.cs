using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeRocket : MonoBehaviour
{
    public float speed = 10.0f;
    public float thrustRegenRate = 0.5f;
    public float maxThrust = 10.0f;
    public float currentThrust = 9.0f;
    public int lives = 3;
    [SerializeField] float rate = 1f;
    private Rigidbody2D rb;

    [SerializeField] GameObject thruster;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lives = 3;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (currentThrust >= 0.5f)
            {
                thruster.SetActive(true);
                

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 direction = (Vector2)(mousePos - transform.position);
                

                direction.Normalize();
                
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                rb.velocity = direction * speed;

                currentThrust -= Time.deltaTime * rate;
            }
            else
            {
                thruster.SetActive(false);
            }
        }
        else
        {
            
            // If the left mouse button is not held down, regenerate the rocket's thrust
            currentThrust += Time.deltaTime * thrustRegenRate;
            currentThrust = Mathf.Clamp(currentThrust, 0, maxThrust);
            thruster.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision) 
    {
        string type = collision.gameObject.tag;
        Debug.Log(type);
        
        if(type == "Planet")
        {
            rb.velocity = Vector2.zero;
            lives--;
        }
        else if(type == "Heart")
        {
            lives++;
        }
    }
}

