using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 0)]
public class Inventory : ScriptableObject
{
    [SerializeField, InlineEditor()] private List<Item> _items;
    
    
    public void SetAmount(Item item, int amount)
    {
        _items[item.index].SetAmount(amount);
    }
    public void Load()
    {
        foreach (Item item in _items)
        {
            item.Load();
        }
    }
    public void Save()
    {
        foreach (Item item in _items)
        {
            item.Save();
        }
    }
    public void Reset()
    {
        foreach (Item item in _items)
        {
            item.Reset();
        }
    }
}