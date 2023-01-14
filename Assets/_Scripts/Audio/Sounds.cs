using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

[Serializable]
public class Sounds 
{
    public string name;

    public AudioClip clip;

    [Range(.1f, 3f)]
    public float pitch = 1f;

    [Range(0.1f, 1f)]
    public float volume = 1f;

    public bool loop;

    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
