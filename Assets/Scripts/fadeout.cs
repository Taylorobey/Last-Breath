using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeout : MonoBehaviour
{
    public Image self;
    private bool fadingin;
    float alpha;

    void Start()
    {
        fadingin = true;
        alpha = 1f;
        self.GetComponent<CanvasRenderer>().SetAlpha(1f);
        GetComponent<Image>().color = Color.black;
    }

    void Update()
    {
        if (PersistentManagerScript.Instance.fadingout == true)
        {
            alpha += 1f * Time.deltaTime;
            self.GetComponent<CanvasRenderer>().SetAlpha(alpha);
            if (alpha > 1)
            {
                fadingin = true;
            }
        }

        if(fadingin == true)
        {
            alpha -= 1f * Time.deltaTime;
            self.GetComponent<CanvasRenderer>().SetAlpha(alpha);
            if(alpha < 0)
            {
                fadingin = false;
            }
        }
    }
}
