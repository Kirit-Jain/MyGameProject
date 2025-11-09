using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform slotContainer;
    public GameObject slotPrefab;

    Inventory inventory;
    List<InventorySlot> slots = new List<InventorySlot>();

    void Start()
    {
        inventory = Inventory.instance;

        inventory.onInventoryChangedCallback += UpdateUI;

        inventoryPanel.SetActive(false);

        CreateSlots();
    }

    public void TogglePanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);

        if(inventoryPanel.activeSelf)
        {
            UpdateUI();
        }
    }

    void CreateSlots()
    {
        for (int i = 0; i < inventory.inventorySize; i++)
        {
            GameObject slotGO = Instantiate(slotPrefab, slotContainer);
            InventorySlot slot = slotGO.GetComponent<InventorySlot>();
            if (slot != null)
            {
                slots.Add(slot);
            }
        }

        UpdateUI();
    }
    
    void UpdateUI()
    {
        for(int i=0; i<slots.Count; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
