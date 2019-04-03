using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phys_button : MonoBehaviour
{
    private Animator animator;
    public GameObject gates;
    int objson;

    void Start()
    {
        objson = 0;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string othername = other.name.Split('_')[0];
        if (other.name == "Player" || othername == "physitem" || othername == "followenemy")
        {
            objson += 1;
            Obsjsoncheck();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        string othername = other.name.Split('_')[0];
        if (other.name == "Player" || othername == "physitem" || othername == "followenemy")
        {
            objson -= 1;
            Obsjsoncheck();
        }
    }

    void Obsjsoncheck()
    {
        if(objson == 0) {
            foreach (Transform child in gates.transform)
            {
                child.gameObject.active = true;
            }
            animator.SetBool("on", false);
        }
        else
        {
            foreach (Transform child in gates.transform)
            {
                if (child != transform)
                {
                    child.gameObject.active = false;
                }    
            }
            animator.SetBool("on", true);
        }
    }
}
