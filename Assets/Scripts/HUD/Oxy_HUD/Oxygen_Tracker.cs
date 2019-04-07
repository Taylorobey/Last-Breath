using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen_Tracker : MonoBehaviour
{
    [SerializeField] int remaining_oxygen;

    float timer = 0.0f; 
    int seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        seconds = (int) timer % 60; 

        if (seconds >0){
            Debug.Log("" + seconds + "\n");
            remaining_oxygen -= seconds;
            seconds = 0;
            timer = 0;
        }
    }

    public int get_Oxy()
    {
        return remaining_oxygen;
    }
}
