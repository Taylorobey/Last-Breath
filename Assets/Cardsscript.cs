using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cardsscript : MonoBehaviour
{
    private int keys = 0;
    private int totalkeys = 0;
    public int index;
    public Image self;
    private Canvas CanvasObject;

    // Start is called before the first frame update
    void Start()
    {
        totalkeys = PersistentManagerScript.Instance.currentkeysneeded;
        Invoke("KeyCheck", 0.05f);
    }

    void KeyCheck()
    {
        if(totalkeys < index)
        {
            self.enabled = false;
        }
        if(keys < index)
        {
            
        }
        else
        {
            self.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        keys = PersistentManagerScript.Instance.currentkeys;
        KeyCheck();
    }
}
