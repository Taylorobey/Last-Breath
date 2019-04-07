using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;


public class MusicManager : SingletonMB<MusicManager>
{
    [SerializeField] private AudioClip levelMusic;
    [SerializeField] private AudioClip menuMusic;
    
    private AudioSource MyAudioSource { get; set; }
    
    
    
    
    protected override void OnAwake()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }


    public void PlayMusicLevel()
    {
        if (MyAudioSource.clip == levelMusic)
            return;
        
        MyAudioSource.clip = levelMusic;
        MyAudioSource.Play();
    }
}
