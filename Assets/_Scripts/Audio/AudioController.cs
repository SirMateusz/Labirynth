using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioController : MonoBehaviour
{
    public static AudioController audioController;

    [SerializeField]
    private Sounds[] sounds;

    private void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        if (audioController == null)
        {
            audioController = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Play("music");
    }

    public void Play(string _name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == _name);
        s.source.Play();
    }
}
