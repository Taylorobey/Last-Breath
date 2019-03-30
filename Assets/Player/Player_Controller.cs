using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float WalkSpeed; // Player walk speed
    private bool Direction;
    float deadzone = 0.25f; // Controller dead zone

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private SpriteRenderer sp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveInput.magnitude < deadzone) // Deadzone
        {
            moveInput = Vector2.zero;
        }

        moveVelocity = moveInput.normalized * WalkSpeed; // Movement speed after input calculations
        directioncheck(moveInput);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void directioncheck(Vector2 input) // Checks what direction the player is moving and flips sprite accordingly
    {
        if (input.x > 0) // Moving right
        {
            Direction = false;
        }

        if (input.x < 0) // Moving left
        {
            Direction = true;
        }

        sp.flipX = Direction; // Sets sprite direction
    }
}
