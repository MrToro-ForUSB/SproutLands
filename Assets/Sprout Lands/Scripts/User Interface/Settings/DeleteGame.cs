using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteGame : MonoBehaviour
{
    // —————————— unity methods
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Delete);
    }


    
    // —————————— class methods
    private void Delete()
    {
        GameManager.DeleteGame();
    }
}
