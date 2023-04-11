using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Pickupable : Entity
{
    // —————————— fields
    [SerializeField] private Item item;
    [SerializeField, ReadOnly] private int siblingIndex = 0;

    [TitleGroup("Audio")] 
    [SerializeField] private AudioClip pickupAudioClip;


    
    // —————————— unity methods
    private void Start()
    {
        siblingIndex = transform.GetSiblingIndex();
        bool isCollected = PlayerPrefs.GetInt($"Item_{siblingIndex}_Collected") == 1;
        
        if (isCollected)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            DeleteEntity();
        }
    }


    // —————————— class methods
    protected override void Move()
    {
        
    }
    protected override void DeleteEntity(params object[] arguments)
    {
        SoundManager.PlaySound(pickupAudioClip);
        
        PlayerPrefs.SetInt($"Item_{siblingIndex}_Collected", 1);
        GameManager.Instance.Inventory.SetAmount(item, 1);
        GameManager.SaveGame();
        
        Destroy(gameObject);
    }
}
