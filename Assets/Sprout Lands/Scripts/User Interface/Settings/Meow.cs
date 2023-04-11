using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meow : MonoBehaviour
{
    // —————————— fields
    [SerializeField] private AudioClip meowAudioClip;

    

    // —————————— unity methods
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayMeow);
    }


    
    // —————————— class methods
    private void PlayMeow()
    {
        SoundManager.PlaySound(meowAudioClip);
    }
}
