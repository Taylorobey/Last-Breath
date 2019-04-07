using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerBehavior : InteractableEntityBase
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
        player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(Collider, PlayerCollider);
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

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //do nothing
    }
}
