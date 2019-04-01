using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OxygenTankType
{
    Single = 1, Double = 2, Triple = 3   
}

public class OxygenTank : InteractableEntityBase
{
    [SerializeField] private OxygenTankType type;
    [SerializeField] private float respawnTime;
    [SerializeField] private SpriteRenderer myTank;
    
    private Coroutine RespawnRoutine { get; set; }
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other == PlayerCollider)
        {
            //add value
            OxygenSystem.Instance.AddTank(type);
            
            //disable view
            myTank.enabled = false;
            Collider.enabled = false;
            
            //respawn it
            RespawnRoutine = StartCoroutine(ScheduleRespawn());
        }
    }

    private IEnumerator ScheduleRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        myTank.enabled = true;
        Collider.enabled = true;
    }

    private void OnDestroy()
    {
        //cleaning
        if (RespawnRoutine != null)
        {
            StopCoroutine(RespawnRoutine);
            RespawnRoutine = null;
        }
    }
}
