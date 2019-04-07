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
    }
}
