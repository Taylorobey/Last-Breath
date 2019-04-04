using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{

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

            switch (direction)
            {

                case 0:
                    otherrb.AddForce(transform.up * 7500);
                    break;
                case 1:
                    otherrb.AddForce(transform.right * 7500);
                    break;
                case 2:
                    otherrb.AddForce(transform.right * -7500);
                    break;
                case 3:
                    otherrb.AddForce(transform.right * 7500);
                    break;

            }
        }
    }

}
