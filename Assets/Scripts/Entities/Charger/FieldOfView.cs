using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FieldOfView : InteractableEntityBase
{
    public Action<Transform> OnPlayerFound = (playerCollider) => { };
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other == PlayerCollider)
        {
            OnPlayerFound?.Invoke(Player.transform);
        }
    }
    
    public override void OnPushed()
    {
        //do nothing
    }
}
