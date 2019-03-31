using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KeysScript : MonoBehaviour
{
    public enum KeyColor
    {
        Red = 0, Blue = 1, Green = 2, Yellow = 3
    }

    public KeyColor color;

    Scene m_Scene;
    string recieve;
    GameObject player;
    Player_Controller pc;  
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); ;
        animator.SetInteger("color", (int)color);
        player = GameObject.Find("Player");
        pc = player.GetComponent<Player_Controller>();
        m_Scene = SceneManager.GetActiveScene();
        for (int i = 0; i < PersistentManagerScript.Instance.collectedkeys.Count; i++) // Looks through all of the collected keys and checks if it is in this list. If it finds itself it deletes itself.
        {
            recieve = PersistentManagerScript.Instance.collectedkeys[i];
            if (recieve == (m_Scene.name + gameObject.name))
            {
                pc.keys += 1;
                Destroy(gameObject);
            }
        }
    }
}
