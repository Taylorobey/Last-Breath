using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Script_Ones : MonoBehaviour
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

        displaynum = oxy_input % 60;
        displaynum = displaynum % 10;

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
            case 6:
            spriteR.sprite = Number_Sprites[6];
            break;
            case 7:
            spriteR.sprite = Number_Sprites[7];
            break;
            case 8:
            spriteR.sprite = Number_Sprites[8];
            break;
            case 9:
            spriteR.sprite = Number_Sprites[9];
            break;
        }
    }
}
