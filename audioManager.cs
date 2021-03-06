using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class audioManager : MonoBehaviour{
    

    public Sound[] sounds;
    float time;

    void Awake() {
        
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        
        
    }

    void start() {
        float time = Time.time;
    }




    // Update is called once per frame
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();
    }
    



}
