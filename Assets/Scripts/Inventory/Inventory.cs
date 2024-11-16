using System;
using UnityEngine;

public class Inventory
{
    public event Action<InventorySlot, int> SlotChanged;

    public readonly InventorySlot[] Slots;

    public Inventory(int maxCountOfItems)
    {
        Slots = new InventorySlot[maxCountOfItems];
        for (int i = 0; i < maxCountOfItems; i++)
        {
            Slots[i] = new InventorySlot();
        }
    }

    public bool AddItem(InventoryItem item)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].TrySetItem(item))
            {
                SlotChanged?.Invoke(Slots[i], i);
                Debug.Log(i + " slot was free");
                return true;
            }
        }

        return false;
    }
}
