using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventorySlotView _slotCellPattern;

    [SerializeField] private List<InventorySlotView> _slots;

    public void SetSlots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _slots.Add(Instantiate(_slotCellPattern));
            _slots[i].transform.SetParent(transform);
        }
    }

    public void RedrawSlot(InventorySlot newSlot, int number)
    {
        _slots[number].SetInfo(newSlot.Item, newSlot.Count);
    }
}