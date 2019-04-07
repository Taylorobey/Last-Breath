using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class InteractableEntityBase : MonoBehaviour
{
    private const int ForcePush = 400;
    private const int ForceTorque = 400;
    //------------------------------------------------------------------------------------------------------------------
    //player reference
    protected Player_Controller Player { get; private set; }
    protected Collider2D PlayerCollider { get; private set; }
    
    //base entity components
    protected Collider2D Collider { get; private set; }
    protected Rigidbody2D Rigidbody { get; private set; }
    protected SpriteRenderer SpriteRenderer { get; private set; }
    protected Animator Animator { get; private set; }
    
    public bool Pushing { get; set; }
    
    
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
    
    public virtual void OnPushed()
    {
        Pushing = true;
        var delta = transform.position - Player.transform.position; 
        Rigidbody.AddForce(delta * ForcePush);
        Rigidbody.AddTorque(ForceTorque);
        StartCoroutine(DestroyDelayed());
    }
    
    private IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    #endregion

    //------------------------------------------------------------------------------------------------------------------
}
