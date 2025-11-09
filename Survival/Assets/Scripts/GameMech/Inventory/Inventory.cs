using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;


    public int inventorySize = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (items.Count >= inventorySize)
        {
            Debug.Log("Inventory is full!");
            return false;
        }

        items.Add(item);

        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }

        return true;
    }
    
    public void Remove(Item item)
    {
        items.Remove(item);

        if(onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }
    }
}
