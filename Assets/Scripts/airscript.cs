using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airscript : MonoBehaviour
{
    private SpriteRenderer sp;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if(PersistentManagerScript.Instance.direction == 2)
        {
            sp.flipX = true;
        }
        Invoke("SDestroy", 0.4f);
    }

    void SDestroy()
    {
        Destroy(gameObject);
    }
}
