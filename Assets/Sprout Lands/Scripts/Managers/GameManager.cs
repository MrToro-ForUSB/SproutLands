using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // —————————— propierties
    public static GameManager Instance { get; private set; }
    public UnityEvent OnSave { get; private set; } = new();
    public Inventory Inventory => inventory;
    
    
    
    // —————————— fields
    [SerializeField] private Inventory inventory;
    
    
    
    // —————————— unity methods
    private void Awake()
    {
        GameManager[] objs = GameObject.FindObjectsOfType<GameManager>();
        
        if (objs.Length > 1) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetDefaultGame();
        }
    }
    
    

    // —————————— class methods
    private void SetDefaultGame()
    {
        bool wasGameLoaded = (PlayerPrefs.GetInt("wasGameLoaded") == 1);
        
        if (wasGameLoaded)
        {
            inventory.Load();
        }
        else
        {
            PlayerPrefs.SetInt("wasGameLoaded", 1);
            PlayerPrefs.SetInt("EffectsVolume", 0);
            PlayerPrefs.SetInt("MusicVolume", 0);
            PlayerPrefs.SetFloat("PlayerPosX", 0.61f);
            PlayerPrefs.SetFloat("PlayerPosY", -6.2f);
            Instance.Inventory.Reset();
        }
    }
    public static void SaveGame()
    {
        Instance.Inventory.Save();
        Instance.OnSave.Invoke();
    }
    public static void DeleteGame()
    {
        PlayerPrefs.DeleteAll();
        Instance.SetDefaultGame();
    }
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
