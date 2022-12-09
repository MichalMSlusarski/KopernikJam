using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody; // The player's rigidbody

    public float moveSpeed = 5.0f; // The speed at which the player moves
    public float jumpForce = 10.0f; // The force applied to the player when jumping

    private bool isGrounded = false; // Whether the player is currently grounded
    public float transformRadius = 0.1f; // The radius of the overlap circle to determine if the player is grounded
    public LayerMask whatIsGround; // A mask determining what is ground to the player

    void Update()
    {
        // Check if the player is grounded by performing a circle overlap test
        isGrounded = Physics2D.OverlapCircle(transform.position, transformRadius, whatIsGround);

        // Get the horizontal input axis
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Move the player horizontally
        rigidbody.velocity = new Vector2(moveHorizontal * moveSpeed, rigidbody.velocity.y);

        // If the player is grounded and the jump button is pressed, add a vertical force to the player
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}

