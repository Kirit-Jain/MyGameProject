using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //Basic Item
    public string itemName = "New Item";
    [TextArea(3, 5)]
    public string itemDescription = "Item description here";
    public Sprite itemIcon = null;


    //Functionality
    public enum ItemType
    {
        Health,
        Hunger,
        Thirst,
        Resource
    }

    public ItemType itemType;
    public float itemValue = 20f;


    public virtual void Use(PlayerStats playersStats)
    {
        switch (itemType)
        {
            case ItemType.Health:
                playersStats.Heal(itemValue);
                break;
            case ItemType.Hunger:
                playersStats.Eat(itemValue);
                break;
            case ItemType.Thirst:
                playersStats.Drink(itemValue);
                break;
            case ItemType.Resource:
                // playersStats.Heal(itemValue);
                break;
        }
    }
}
