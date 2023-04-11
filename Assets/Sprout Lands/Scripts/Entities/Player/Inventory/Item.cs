using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    public int index;
    public string itemKey;

    [TitleGroup("Details")]
    [PreviewField] public Sprite sprite;
    [SerializeField, ReadOnly] private int amount;


    public void SetAmount(int amount)
    {
        this.amount += amount;
    }
    public void Load()
    {
        amount = PlayerPrefs.GetInt(itemKey);
    }
    public void Save()
    {
        PlayerPrefs.SetInt(itemKey, amount);
    }
    public void Reset()
    {
        amount = 0;
        PlayerPrefs.SetInt(itemKey, amount);
    }
}