using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonscript : MonoBehaviour
{
    void Start()
    {
        if(PersistentManagerScript.Instance.gun == true)
        {
            Destroy(gameObject);
        }
    }
}
