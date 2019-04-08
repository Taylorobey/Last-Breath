using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicplayer : MonoBehaviour
{
    private AudioSource audiosource = null;
    public AudioClip music;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Audio");
        AudioSource audsrc = player.GetComponent<AudioSource>();
        audsrc.PlayOneShot(music);
    }
}
