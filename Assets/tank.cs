using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movement; // Store movement direction
    private float currentAngle; // Current rotation angle

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        currentAngle = 0f; // Initialize current angle
    }

    void Update()
    {
        // Get input from keyboard
        movement.x = 0; // Reset x movement
        movement.y = 0; // Reset y movement

        if (Input.GetKey(KeyCode.W)) // Move Up
        {
            movement.y = 1;
            currentAngle = 0f; // Set angle to 0°
        }
        else if (Input.GetKey(KeyCode.S)) // Move Down
        {
            movement.y = -1;
            currentAngle = 180f; // Set angle to 180°
        }
        else if (Input.GetKey(KeyCode.A)) // Move Left
        {
            movement.x = -1;
            currentAngle = 90f; // Set angle to 270°
        }
        else if (Input.GetKey(KeyCode.D)) // Move Right
        {
            movement.x = 1;
            currentAngle = 270f; // Set angle to 90°
        }

        // Normalize the movement vector to avoid faster diagonal movement
        if (movement != Vector2.zero)
        {
            movement.Normalize();
            RotateSprite(currentAngle); // Rotate the sprite based on the current angle
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void RotateSprite(float angle)
    {
        // Set the rotation of the Rigidbody2D
        rb.rotation = angle; // Set the rotation of the Rigidbody2D
    }
}