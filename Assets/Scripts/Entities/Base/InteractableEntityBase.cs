using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class InteractableEntityBase : MonoBehaviour
{    
    //------------------------------------------------------------------------------------------------------------------
    //player reference
    protected Player_Controller Player { get; private set; }
    protected Collider2D PlayerCollider { get; private set; }
    
    //base entity components
    protected Collider2D Collider { get; private set; }
    protected Rigidbody2D Rigidbody { get; private set; }
    protected SpriteRenderer SpriteRenderer { get; private set; }
    protected Animator Animator { get; private set; }
    
    //------------------------------------------------------------------------------------------------------------------
    
    
    #region Unitycallbacks
    
    
    protected virtual void Awake()
    {
        //caching in player and collider components
        Player = FindObjectOfType<Player_Controller>();
        PlayerCollider = Player.GetComponent<Collider2D>();
        Collider = GetComponentInChildren<Collider2D>();
        Rigidbody = GetComponentInChildren<Rigidbody2D>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    ///     Base Trigger. You must override it in the concrete classes.
    /// </summary>
    /// <param name="other"></param>
    protected abstract void OnTriggerEnter2D(Collider2D other);

    #endregion

    //------------------------------------------------------------------------------------------------------------------
}
