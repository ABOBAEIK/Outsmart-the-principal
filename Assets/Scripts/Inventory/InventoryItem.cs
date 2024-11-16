using System;
using System.IO;
using UnityEngine;

using GameDatas;

public class InventoryItem
{
    public static readonly InventoryItem[] AllItems;

    public static readonly InventoryItem Empty;


    public readonly string Name;

    public readonly Sprite Icon;

    public readonly InventoryItemType ItemType;

    static InventoryItem()
    {
        ItemData[] items = Game.AllGameData.MainGame.Items;

        AllItems = new InventoryItem[items.Length];

        string iconPath = null;
        for (int i = 0; i < items.Length; i++)
        {
            iconPath = items[i].Icon;

            Sprite itemIcon = Resources.Load<Sprite>(iconPath);
            if (itemIcon == null)
                Debug.Log(items[i].Icon + " – path doesnt exist");

            AllItems[i] = new InventoryItem(items[i].Name, itemIcon, (InventoryItemType)i);
        }

        Empty = AllItems[0];
    }

    public static InventoryItem GetInventoryItem(InventoryItemType type)
    {
        Debug.Log("Getting transform item to: " + AllItems[(int)type].Name);
        return AllItems[(int)type];
    }

    private InventoryItem(string name, Sprite icon, InventoryItemType itemType)
    {
        Name = name;
        Icon = icon;
        ItemType = itemType;
    }
}
