using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followenemy : MonoBehaviour
{
    #region Variables
    public Transform Player;
    public float WalkSpeed = 3f;
    private SpriteRenderer sp;
    private bool PInLOS;
    GameObject player;
    #endregion

    void Start()
    {
        PInLOS = false;
        sp = GetComponent<SpriteRenderer>();
    }

    #region Methods
    void FixedUpdate()
    {
        if (gameObject.transform.position.y < Player.position.y)
        {
            transform.Translate(transform.up*(WalkSpeed/100));
        }
        else
        {
            transform.Translate(transform.up* -(WalkSpeed / 100));
        }

        if(gameObject.transform.position.x < Player.position.x)
        {
            transform.Translate(transform.right * (WalkSpeed / 100));
        }
        else
        {
            transform.Translate(transform.right * -(WalkSpeed / 100));
        }
    }
    #endregion
}
