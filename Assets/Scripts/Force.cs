using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public int forceAmount = 7500;
    public int direction;

    // Update is called once per frame
    void Awake() { 

        if(direction == null)
        {
            direction = 0; 
        }
    }

    void Start()
    {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
        direction = PersistentManagerScript.Instance.direction;
        Invoke("SDestroy", 0.1f);
    }

    void SDestroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string othername = other.name.Split('_')[0];
        if (othername == "physitem" || othername == "followenemy" || othername == "Sniffer")
        {
            Rigidbody2D otherrb;
            otherrb = other.GetComponent<Rigidbody2D>();
            direction = PersistentManagerScript.Instance.direction;
            switch (direction)
            {
                case 1:
                    otherrb.AddForce(transform.right * forceAmount);
                    break;
                case 2:
                    otherrb.AddForce(transform.right * -forceAmount);
                    break;
                case 3:
                    otherrb.AddForce(transform.up * -forceAmount);
                    break;
                case 4:
                    otherrb.AddForce(transform.up * forceAmount);
                    break;
            }
        }

        TryPushEnemies(other);
    }


    private void TryPushEnemies(Collider2D other)
    {
        if (other != null)
        {
            var entity = other.GetComponent<InteractableEntityBase>();
            if(entity)
                entity.OnPushed();
        }
    }
}
