using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{

    // ----------------------------------------------

    #region Fields and Properties
    // --------- Movement -----------------
    float WalkSpeed; // Player walk speed
    float Sprintspeed;
    private bool Direction;
    float deadzone = 0.25f; // Controller dead zone
    private bool sprinting;
    Vector2 moveInput = new Vector2();
    // ------------------------------------

    private string[] otherprefab; // Current object overlapping trigger

    private bool overdoor; // ------------
    private string doorlevel; // Door
    private int doorsp; // ---------------

    private bool savedir;
    private bool frontback; // Walking up or down
    private int fouraxisdir;
    private GameObject keyobj; // --------
    private int keysneeded; // Keys
    public int keys; // ------------------

    private GameObject doorobject;
    private Animator animator;
    private Animator dooranimator;
    Scene m_Scene;
    public GameObject force = null;
    public GameObject air = null;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private SpriteRenderer sp;
    string othername; // Name of object overlapping trigger
    #endregion

    // ----------------------------------------------

    void Start()
    {
        PersistentManagerScript.Instance.currentkeys = 0;
        //subscribe death trigger
        OxygenSystem.OnDie += Die;
        
        savedir = false;
        m_Scene = SceneManager.GetActiveScene();
        animator = GetComponent<Animator>();
        WalkSpeed = 5f;
        Sprintspeed = 6.75f;

        fouraxisdir = 1;

        var objects = FindObjectsOfType<GameObject>(); // Get number of keys needed to complete room
        for (int i = 0; i < objects.Length; i++)
        {
            if((objects[i].name.Split('_')[0]) == "key")
            {
                keysneeded++;
            }
        }
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        PersistentManagerScript.Instance.currentkeysneeded = keysneeded;

        if (PersistentManagerScript.Instance.SpawnPoint != 0)
        {
            GameObject[] spawnpoints;
            spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

            for (int i = 0; i < spawnpoints.Length; i++)
            {
                if(int.Parse(spawnpoints[i].name.Split('_')[1]) == PersistentManagerScript.Instance.SpawnPoint)
                {
                    transform.position = spawnpoints[i].transform.position;
                }
            }
        }

    }

    void Update()
    {

        // ----------------------------------------------

        #region Input
        moveInput.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Interact ---
        if (Input.GetKeyDown("joystick button 2"))
        {
            Interact();
        }

        if (Input.GetKeyDown("e"))
        {
            Interact();
        }
        // Interact ---

        // Fire ---
        if (Input.GetKeyDown("f"))
        {
            FireGun();
        }

        if (Input.GetKeyDown("joystick button 0")){
            FireGun();
        }
        // Fire ---

        // Sprint ---
        if (Input.GetAxisRaw("Sprint") > 0 || Input.GetAxisRaw("Sprint_K") > 0)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }
        // Sprint ---

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
            moveVelocity = moveInput.normalized * (WalkSpeed + (Sprintspeed - WalkSpeed)); // Sprint speed
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
        #endregion

        // ----------------------------------------------

        if (moveInput.x > 0) // Looking right
        {
            fouraxisdir = 1;
        }
        if (moveInput.x < 0) // Looking left
        {
            fouraxisdir = 2;
        }
        //if (moveInput.y < 0) // Looking down
        //{
        //    fouraxisdir = 3;
        //}
        //if (moveInput.y > 0) // Looking up
        //{
        //    fouraxisdir = 4;
        //}
        animator.SetBool("Direction", frontback);
        animator.SetFloat("Speed", ((Mathf.Abs(moveInput.x) + Mathf.Abs(moveInput.y))/2));
        animator.SetBool("gun", PersistentManagerScript.Instance.gun);
        directioncheck(moveInput);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void directioncheck(Vector2 input) // Checks what direction the player is moving and flips sprite accordingly
    {
        if(moveInput.x > 0)
        {
            if (frontback == true)
            {
                Direction = false;
                savedir = false;
            }
            else
            {
                Direction = true;
                savedir = false;
            }
        }
        else
        {
            if (moveInput.x < 0)
            {
                if (frontback == true)
                {
                    Direction = true;
                    savedir = true;
                }
                else
                {
                    Direction = false;
                    savedir = true;
                }
            }
        }
        if (moveInput.x == 0 && Mathf.Abs(moveInput.y) > 0)
        {
            if (frontback == true)
            {
                Direction = savedir;
            }
            else
            {
                Direction = !savedir;
            }
        }
        sp.flipX = Direction;

    }

    void OnTriggerEnter2D(Collider2D other) // Trigger overlap
    {
        othername = other.name;
        otherprefab = (othername.Split(':')[0]).Split('_');

        switch (otherprefab[0])
        {
            case "door":
                overdoor = true;
                doorsp = int.Parse(othername.Split(':')[1]);
                doorobject = GameObject.Find(othername);
                dooranimator = doorobject.GetComponent<Animator>();
                doorlevel = otherprefab[1];
                if (overdoor == true && keys >= keysneeded)
                {
                    dooranimator.SetBool("open", true);
                }
                break;
            case "key": // Key pickup
                PersistentManagerScript.Instance.AddKey();
                PersistentManagerScript.Instance.collectedkeys.Add(m_Scene.name + othername);
                keyobj = GameObject.Find(othername);
                keys++;
                Destroy(keyobj);
                break;
            case "cannon":
                GameObject cannon = GameObject.Find(othername);
                Destroy(cannon);
                PersistentManagerScript.Instance.gun = true;
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

    void FireGun()
    {
        if (PersistentManagerScript.Instance.gun == true)
        {
            Vector3 position;
            var offset = 2.5f;
            PersistentManagerScript.Instance.direction = fouraxisdir;
            if (Direction == false)
            {
                if (frontback == true)
                {
                    position = transform.position + (transform.right * offset);
                }
                else
                {
                    position = transform.position + (transform.right * -offset);
                }
            }
            else
            {
                if (frontback == true)
                {
                    position = transform.position + (transform.right * -offset);
                }
                else
                {
                    position = transform.position + (transform.right * offset);
                }
            }
            Instantiate(force, position, Quaternion.identity);
            Instantiate(air, position, Quaternion.identity);
        }
    }

    Vector3 GetOffset()
    {
        var offset = 2.5f;
        switch (fouraxisdir)
        {
            case 1:
                return transform.right * offset; 
            case 2:
                return transform.right * -offset;
            //case 3:
            //    return transform.up * -offset;
            //case 4: return transform.up * offset;
            default: return transform.right * offset; 
        }
    }

    void Interact() // Interactions
    {
        if (overdoor == true && keys >= keysneeded)
        {
            PersistentManagerScript.Instance.SpawnPoint = doorsp;
            Application.LoadLevel(doorlevel);
        }
    }
    
    private void Die()
    {
        WalkSpeed = 0;
        Sprintspeed = 0;
    }

    private void OnDestroy()
    {
        //unsubscribe death trigger
        OxygenSystem.OnDie -= Die;
    }
}
