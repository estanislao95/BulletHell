using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup group;
    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public GameObject gameObject;
    [Range(0,1)]
    public float volume;
    [Range(-3, 3)]
    public float pitch;
    public bool playOnAwake;
    public bool loop;
}
