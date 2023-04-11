using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    // —————————— propierties
    public static SoundManager Instance => instance;
    
    
    
    // —————————— fields
    private static SoundManager instance;
    [SerializeField] private AudioMixer mixer;
    


    // —————————— unity methods
    private void Awake()
    {
        SoundManager[] objs = GameObject.FindObjectsOfType<SoundManager>();
        
        if (objs.Length > 1) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        mixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume"));
        mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    
    
    // —————————— class methods
    public static void PlaySound(AudioClip audio)
    {
        AudioSource temporalAudioSource = instance.gameObject.AddComponent<AudioSource>();
        Destroy(temporalAudioSource, audio.length);

        temporalAudioSource.outputAudioMixerGroup = instance.mixer.FindMatchingGroups("Effects")[0];
        temporalAudioSource.PlayOneShot(audio);
    }
    public static void SetVolume(string key, float volume)
    {
        PlayerPrefs.SetFloat(key, volume);
        instance.mixer.SetFloat(key, volume);
    }
    public static float GetVolume(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }
}
