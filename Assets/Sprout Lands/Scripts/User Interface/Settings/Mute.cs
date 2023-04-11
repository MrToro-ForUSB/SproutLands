using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    // —————————— fields
    private int currentState = 0;
    [SerializeField] private string volumeKey;
    private float volume;

    [SerializeField] private Image image;
    [SerializeField] private Button button;
    [SerializeField, Space] private List<MuteSprite> muteSpritesList;
    
    [Serializable]
    public struct MuteSprite
    {
        [PreviewField, HorizontalGroup] public Sprite defaultSprite;
        [PreviewField, HorizontalGroup] public Sprite pressedSprite;
    }

    

    // —————————— unity methods
    private void Start()
    {
        button.onClick.AddListener(ToggleMute);
    }

    private void OnEnable()
    {
        volume = SoundManager.GetVolume(volumeKey);
        currentState = (volume == 0) ? 0 : 1;
        SetButtonImages(muteSpritesList[currentState]);
    }


    
    // —————————— class methods
    private void ToggleMute()
    {
        if (currentState == 0)
        {
            volume = -80;
            currentState = 1;
        }
        else
        {
            volume = 0;
            currentState = 0;
        }
        
        SoundManager.SetVolume(volumeKey, volume);
        SetButtonImages(muteSpritesList[currentState]);
    }
    private void SetButtonImages(MuteSprite sprites)
    {
        image.sprite = sprites.defaultSprite;

        SpriteState spriteState = button.spriteState;
        spriteState.pressedSprite = sprites.pressedSprite;
        button.spriteState = spriteState;
    }
}
