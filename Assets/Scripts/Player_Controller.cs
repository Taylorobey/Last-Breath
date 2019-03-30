using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    float WalkSpeed; // Player walk speed
    float Sprintspeed;
    private bool Direction;
    float deadzone = 0.25f; // Controller dead zone
    private string[] otherprefab; // Current object overlapping trigger
    private bool overdoor;
    private string doorlevel;
    private bool sprinting;
    private bool frontback; // Walking up or down
    private GameObject keyobj;
    private int keysneeded;
    private int keys;
    private Animator animator;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private SpriteRenderer sp;
    string othername; // Name of object overlapping trigger

    void Start()
    {
        animator = GetComponent<Animator>();
        WalkSpeed = 4f;
        Sprintspeed = 5.5f;

        var objects = FindObjectsOfType<GameObject>();
        for (int i = 0; i < objects.Length; i++)
        {
            if((objects[i].name.Split('_')[0]) == "key")
            {
                keysneeded++;
            }
        }

        keys = 0;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown("joystick button 2"))
        {
            Interact();
        }

        if (Input.GetKeyDown("e"))
        {
            Interact();
        }

        if (Input.GetAxisRaw("Sprint") > 0 || Input.GetAxisRaw("Sprint_K") > 0)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }

        if (moveInput.magnitude < deadzone) // Deadzone
        {
            moveInput = Vector2.zero;
        }

        if (sprinting == false) // W
        {
            moveVelocity = moveInput.normalized * WalkSpeed; // Movement speed after input calculations
        }
        else
        {
            moveVelocity = moveInput.normalized * (WalkSpeed + (Sprintspeed - WalkSpeed)); // sprint speed
        }

        if(moveInput.y > 0)
        {
            frontback = false;
        }
        else
        {
            if(moveInput.y < 0)
            {
                frontback = true;
            }
        }

        animator.SetBool("Direction", frontback);
        animator.SetFloat("Speed", ((Mathf.Abs(moveInput.x) + Mathf.Abs(moveInput.y))/2));
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
            if (frontback == false)
            {
                Direction = true;
            }
            else
            {
                Direction = false;
            }
        }

        if (input.x < 0) // Moving left
        {
            if (frontback == false)
            {
                Direction = false;
            }
            else
            {
                Direction = true;
            }
        }

        sp.flipX = Direction; // Sets sprite direction

    }

    void OnTriggerEnter2D(Collider2D other) // Trigger overlap
    {
        othername = other.name;
        otherprefab = othername.Split('_');

        switch (otherprefab[0])
        {
            case "door":
                overdoor = true;
                doorlevel = otherprefab[1];
                break;
            case "key": // Key pickup
                keyobj = GameObject.Find(othername);
                keys++;
                Destroy(keyobj);
                break;
        }
    }

    void OnTriggerExit2D(Collider2D other) // Trigger exit overlap
    {
        othername = other.name;
        otherprefab = othername.Split('_');

        switch (otherprefab[0])
        {
            case "door":
                overdoor = false;
                break;
        }
    }

    void Interact() // Interactions
    {
        if (overdoor == true && keys >= keysneeded)
        {
            Application.LoadLevel(doorlevel);
        }
    }
}
