using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainCamera : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main; 
    }
}
