public class InventorySlot
{
    public InventoryItem Item { get; private set; }
    
    public int Count { get; private set; }

    public InventorySlot()
    {
        Item = InventoryItem.Empty;
        Count = 0;
    }

    public bool TrySetItem(InventoryItem item)
    {
        if (Item.ItemType == InventoryItemType.None)
        {
            Item = item;
            Count = 1;

            return true;
        }
        else if (Item.ItemType == item.ItemType)
        {
            Count++;

            return true;
        }

        return false;
    }

    public void RemoveItem()
    {
        Item = InventoryItem.Empty;
        Count = 0;
    }
}