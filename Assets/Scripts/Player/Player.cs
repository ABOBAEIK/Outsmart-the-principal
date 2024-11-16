using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerItemTaker _itemTaker;

    [Header("View")]
    [SerializeField] private InventoryView _inventoryView;

    public Inventory Inventory { get; private set; }

    private void Awake()
    {
        Inventory = new Inventory(6);
        _inventoryView.SetSlots(6);
    }

    private void OnEnable()
    {
        _itemTaker.ItemTakingFinished += AddItemToInventory;

        Inventory.SlotChanged += RedrawInventorySlot;
    }

    private void OnDisable()
    {
        _itemTaker.ItemTakingFinished -= AddItemToInventory;

        Inventory.SlotChanged -= RedrawInventorySlot;
    }

    private void AddItemToInventory(SpatialItem item)
    {
        Inventory.AddItem(item.ToInventoryItem());
    }

    private void RedrawInventorySlot(InventorySlot newSlot, int number)
    {
        _inventoryView.RedrawSlot(newSlot, number);
    }
}