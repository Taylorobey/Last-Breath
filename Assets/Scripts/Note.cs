using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    void Start()
    {
        RemoveNote_NonDebugBuilds();
    }

    private void RemoveNote_NonDebugBuilds()
    {
        if(!Application.isEditor)
            Destroy(gameObject);
    }
}
