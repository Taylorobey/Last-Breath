using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Starts()
    {
        Application.LoadLevel("Level0Start");
    }
}
