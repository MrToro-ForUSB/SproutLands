using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DefaultButtonActions : MonoBehaviour
{
    // —————————— fields
    private bool isSelected;
    private bool isHighlighted;
    private GameObject selectionArea;
    
    [SerializeField] private GameObject selectionAreaPrefab;
    [SerializeField] private AudioClip selectedAudioClip;
    [SerializeField] private AudioClip pressedAudioClip;

    

    // —————————— unity methods
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    private void Update()
    {
        isSelected = EventSystem.current.currentSelectedGameObject == gameObject;

        if (isSelected && !isHighlighted)
            OnSelected();
        else if (!isSelected && isHighlighted)
            OnDeselected();
    }


    
    // —————————— class methods
    private void OnClick()
    {
        SoundManager.PlaySound(pressedAudioClip);
    }
    private void OnSelected()
    {
        SoundManager.PlaySound(selectedAudioClip);
        
        selectionArea = Instantiate(selectionAreaPrefab, transform);
        isHighlighted = true;
    }
    private void OnDeselected()
    {
        Destroy(selectionArea);
        selectionArea = null;
        isHighlighted = false;
    }
}
