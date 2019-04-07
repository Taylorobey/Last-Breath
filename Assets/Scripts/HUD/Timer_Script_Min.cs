using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Script_Min : MonoBehaviour
{
    [SerializeField] GameObject OxySource;
    [SerializeField] Sprite[] Number_Sprites = new Sprite[0];
    [SerializeField] int oxy_input;
    private SpriteRenderer spriteR;
    int displaynum = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //change source to get oxygen system input
        oxy_input = OxySource.GetComponent<Oxygen_Tracker_test>().oxytrack;

        displaynum = oxy_input/60;


        //display the number
        switch (displaynum){
            case 0:
            spriteR.sprite = Number_Sprites[0];
            break;
            case 1:
            spriteR.sprite = Number_Sprites[1];
            break;
            case 2:
            spriteR.sprite = Number_Sprites[2];
            break;
            case 3:
            spriteR.sprite = Number_Sprites[3];
            break;
            case 4:
            spriteR.sprite = Number_Sprites[4];
            break;
            case 5:
            spriteR.sprite = Number_Sprites[5];
            break;
        }
    }
}
