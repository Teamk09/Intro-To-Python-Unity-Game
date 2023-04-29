using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f; // Movement speed 

    private Rigidbody2D rb2d;
    private Vector2 movement;
    public Animator animator;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Get horizontal and vertical input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Checks which direction the player is trying to move in
        if (horizontalInput != 0 && verticalInput == 0)
        {
            movement = new Vector2(horizontalInput, 0f).normalized; // Only allows horiztonal movement
        }
        else if (verticalInput != 0 && horizontalInput == 0)
        {
            movement = new Vector2(0f, verticalInput).normalized; // Only allows vertical movement
        }
        else
        {
            movement = Vector2.zero; // Makes sure the player doesn't keep moving if no keys are being pressed
        }

        // Update animator parameters based on movement input
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Speed", movement.magnitude);
    }

    void FixedUpdate()
    {
        // Move the player using the Rigidbody2D component
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }


}
