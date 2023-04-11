using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private AudioClip playAudioClip;
    
    
    
    // —————————— unity methods
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Play);
    }


    
    // —————————— class methods
    private void Play()
    {
        SoundManager.PlaySound(playAudioClip);
        GameManager.LoadScene(1);
    }
}
