using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndExit : MonoBehaviour
{
    [SerializeField] private AudioClip exitAudioClip;
 
    
    
    // —————————— unity methods
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Play);
    }


    
    // —————————— class methods
    private void Play()
    {
        SoundManager.PlaySound(exitAudioClip);
        
        GameManager.SaveGame();
        GameManager.LoadScene(0);
    }
}
