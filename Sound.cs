using System;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // altfel unity nu recunoaste clasa
 public class Sound {
   public string name;
   public AudioClip clip;
   [Range(0f, 1f)]
   public float volume;
   [Range(0.1f, 3f)]
   public float pitch;
   public AudioMixerGroup mixer;

  

   [HideInInspector]
   public AudioSource source;

 }
