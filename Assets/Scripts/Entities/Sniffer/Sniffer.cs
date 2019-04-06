using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniffer : InteractableEntityBase
{
    [Header("Charge Configs")][SerializeField] [Range(10, 70)] [Tooltip("Damage in seconds dealt to the player")]
    private int snifferDamage = 50;
    public bool CanDoDamage { get; set; }


    private void Start()
    {
        CanDoDamage = true;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other == PlayerCollider)
        {
            if (CanDoDamage)
            {
                CanDoDamage = false;
                //deals damage to the player
                DoDamage();
                StartCoroutine(InvullForSeconds(2));
            }
        }
    }
    
    private IEnumerator InvullForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        CanDoDamage = true;
    }

    private void DoDamage()
    {
        if(OxygenSystem.Instance)
            OxygenSystem.Instance.RemoveTime(snifferDamage);
    }
}
