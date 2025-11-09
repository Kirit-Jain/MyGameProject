using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button useButton;

    Item item;
    PlayerStats playersStats;

    void Start()
    {
        playersStats = FindFirstObjectByType<PlayerStats>();

        if (useButton != null)
        {
            useButton.onClick.AddListener(onUseButton);
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.itemIcon;
        icon.enabled = true;
        useButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        useButton.interactable = false;
    }
    
    public void onUseButton()
    {
        if(item != null)
        {
            item.Use(playersStats);

            Inventory.instance.Remove(item);
        }
    }
}
