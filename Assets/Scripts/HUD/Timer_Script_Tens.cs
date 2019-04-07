using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Script_Tens : MonoBehaviour
{
    [SerializeField] Sprite[] Number_Sprites = new Sprite[0];
    private Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        OxygenSystem.OnConsumeOxygenInSeconds += TickTime;
    }
    
    private void OnDestroy()
    {
        OxygenSystem.OnConsumeOxygenInSeconds -= TickTime;
    }

    // Update is called once per frame
    void TickTime(int seconds)
    {

        var num = seconds % 60;
        num = num / 10;

        //display the number
        switch (num){
            case 0:
            image.sprite = Number_Sprites[0];
            break;
            case 1:
            image.sprite = Number_Sprites[1];
            break;
            case 2:
            image.sprite = Number_Sprites[2];
            break;
            case 3:
            image.sprite = Number_Sprites[3];
            break;
            case 4:
            image.sprite = Number_Sprites[4];
            break;
            case 5:
            image.sprite = Number_Sprites[5];
            break;
            case 6:
            image.sprite = Number_Sprites[6];
            break;
            case 7:
            image.sprite = Number_Sprites[7];
            break;
            case 8:
            image.sprite = Number_Sprites[8];
            break;
            case 9:
            image.sprite = Number_Sprites[9];
            break;
        }
    }
}
