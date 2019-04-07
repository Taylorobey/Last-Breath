using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capturezone : MonoBehaviour
{
    private GameObject enemy;

    void Start()
    {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string othername = other.name.Split('_')[0];
        if (othername == "followenemy" || othername == "Sniffer" || othername == "ChargerPrefab")
        {
            Rigidbody2D otherrb;
            otherrb = other.GetComponent<Rigidbody2D>();
            enemy = GameObject.Find(other.name);
            Destroy(enemy);
        }
    }
}
