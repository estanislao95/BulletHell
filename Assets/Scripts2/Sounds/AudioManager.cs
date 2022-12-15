using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    public static AudioManager instance;

    [SerializeField] AudioMixerGroup defaultMixer;
    // Start is called before the first frame update

    public Sound[] sounds;

    public string music = "";
     
    public override void PersonalAwake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        foreach (var s in sounds) //ejecuta por cada item en una colleccion. Funciona para casi todo tipo
        {
            if (s.gameObject)
                s.source = s.gameObject.AddComponent<AudioSource>();//crea componente Audiosource
            else
                s.source = gameObject.AddComponent<AudioSource>();//crea componente Audiosource
            s.source.clip = s.clip;
            if (s.group == null)
                s.group = defaultMixer;
            s.source.outputAudioMixerGroup = s.group;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;
            //s.source.spatialBlend = 1;
            //s.source.dopplerLevel = 0;
            //s.source.maxDistance = 50;
            if (s.playOnAwake)
            {
                s.source.Play();
            }
        }
    }

    public void Play (string name, bool isMusic = false)
    {
        Sound s = Array.Find(sounds, sonido => sonido.name == name);
        if (s != null) //si hay un sonido que coincide
        {

            if (isMusic)
            {
                print("is music");
                //if (IsAudioPlaying(name)) return;

                Stop(music);

                music = name;
            }

            s.source.Play();
            //s.Music = isMusic;
        }
        else
            print("no existe el sonido " + name);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sonido => sonido.name == name);
        if (s != null) //si hay un sonido que coincide
        {
            s.source.Stop();
        }
        else
            print("no existe el sonido " + name);
    }


    public bool IsAudioPlaying(string name)
    {
        bool result = false;

        Sound s = Array.Find(sounds, sonido => sonido.name == name);
        if (s != null) //si hay un sonido que coincide
        {
            if (s.source.isPlaying)
            {
                result = true;
            }
        }

        return result;
    }

    //#region audioValuesGetAndUpdate
    //void UpdateAudio(float volume, string volumeVariable)
    //{
    //    GameManager.instance.mainAudioMixer.SetFloat(volumeVariable, volume);
    //}
    //
    //public void UpdateMusicVolume(float volume)
    //{
    //    UpdateAudio(volume, "musicVolume");
    //}
    //
    //public void UpdateSoundVolume(float volume)
    //{
    //    UpdateAudio(volume, "soundVolume");
    //}
    //
    //public float GetMusicVolume()
    //{
    //    float volume;
    //    GameManager.instance.mainAudioMixer.GetFloat("musicVolume", out volume);
    //
    //    return volume;
    //}
    //
    //public float GetSoundVolume()
    //{
    //    float volume;
    //    GameManager.instance.mainAudioMixer.GetFloat("soundVolume", out volume);
    //
    //    return volume;
    //}
    //#endregion
}
