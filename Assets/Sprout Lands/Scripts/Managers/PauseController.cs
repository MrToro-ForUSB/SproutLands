using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    // —————————— propierties
    public static PauseController Instance => instance;
    
    
    
    // —————————— fields
    private static PauseController instance;
    private bool isPaused = false;
    [SerializeField] private UnityEvent onPause;
    [SerializeField] private UnityEvent onUnPause;


    // —————————— unity methods
    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Pause"))
        {
            SwitchPauseStatement();
        }
    }


    // —————————— class methods
    public void SwitchPauseStatement()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            onPause.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            onUnPause.Invoke();
        }
    }
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
