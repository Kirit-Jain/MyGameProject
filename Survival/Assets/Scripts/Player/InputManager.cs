using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InventoryUI inventoryUI;

    void Start()
    {
        if (inventoryUI == null)
        {
            inventoryUI = FindFirstObjectByType<InventoryUI>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.TogglePanel();
        }
    }
}
