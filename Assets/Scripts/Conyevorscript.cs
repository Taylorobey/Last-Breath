using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conyevorscript : MonoBehaviour
{

    public enum Direction
    {
        Up = 0, Down = 1, Left = 2, Right = 3
    }

    public List<Collider2D> goList = null;
    public Direction dir;

    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D otherrb;
        goList.Add(other);
        otherrb = other.GetComponent<Rigidbody2D>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        for(int i = 0; i < goList.Count; i++)
        {
            if (goList[i].name == other.name)
            {
                goList.RemoveAt(i);
            }
        }
    }

    void Update()
    {
        foreach(Collider2D other in goList)
        {
           Rigidbody2D otherrb;
           otherrb = other.GetComponent<Rigidbody2D>();
            switch ((int)dir)
            {
                case 0:
                    otherrb.AddForce(transform.up * 100);
                    break;
                case 1:
                    otherrb.AddForce(transform.up * -100);
                    break;
                case 2:
                    otherrb.AddForce(transform.right * -100);
                    break;
                case 3:
                    otherrb.AddForce(transform.right * 100);
                    break;
            }
        }
    }
}
