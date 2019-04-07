using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    [SerializeField] Sprite[] needle_frame = new Sprite[0];
    [SerializeField] GameObject hudref;
    [SerializeField] int framecounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        framecounter = hudref.Oxygen_Tracker.remaining_oxygen;
    }
}
