using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<InventoryInfo> itemList;


    public event EventHandler OnItemListChanged;
    public specimen2 specimen;

    public InventoryController()
    {
        itemList = new List<InventoryInfo>();
        specimen = GameObject.Find("Player").GetComponent<specimen2>();
        specimen.LoadPlayer();
        /*        AddItem(new InventoryInfo { itemType = InventoryInfo.ItemType.XpPotion, amount = 1 });
        */
    }




    public void AddItem(InventoryInfo item)
    {
        bool itemAlreadyInInventory = false;
        foreach(InventoryInfo inventoryItem in itemList)
        {
            if(inventoryItem.itemType == item.itemType)
            {
                inventoryItem.amount += item.amount;
                itemAlreadyInInventory = true;
            }
        }
        if(!itemAlreadyInInventory)
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(InventoryInfo item)
    {
        InventoryInfo itemInInventory = null;
        foreach (InventoryInfo inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item.itemType)
            {
                inventoryItem.amount -= 1;
                itemInInventory = inventoryItem;
                
            }
        }
        if (itemInInventory != null && itemInInventory.amount <= 0)
        {
            itemList.Remove(itemInInventory);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(InventoryInfo item)
    {
        //Use item
        switch (item.itemType)
        {
            default:
            case InventoryInfo.ItemType.XpPotion:
                specimen.xp += 10;
                specimen.SavePlayer();
                break;
            case InventoryInfo.ItemType.StrengthPotion:
                specimen.strength += 1;
                specimen.SavePlayer();
                break;
            case InventoryInfo.ItemType.EndurancePotion:
                specimen.endurance += 1;
                specimen.SavePlayer();
                break;
            case InventoryInfo.ItemType.IntelligencePotion:
                specimen.intelligence += 1;
                specimen.SavePlayer();
                break;
        }
        RemoveItem(item);
    }

    public List<InventoryInfo> GetItemList()
    {
        return itemList;
    }

    public void Save()
    {
        List<InventoryInfo.ItemType> itemL = new List<InventoryInfo.ItemType>();
        List<int> itemA = new List<int>();
        foreach (InventoryInfo inventoryItem in itemList)
        {
            itemL.Add(inventoryItem.itemType);
            itemA.Add(inventoryItem.amount);
        }
        SaveObject saveObject = new SaveObject
        {
            itemL = itemL,
            itemA = itemA,
        };
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/invsave.txt", json);
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/invsave.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/invsave.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            for (int i = 0; i < saveObject.itemL.Count; i++)
            {
                AddItem(new InventoryInfo { itemType = saveObject.itemL[i], amount = saveObject.itemA[i] });
            }

        }
    }

    private class SaveObject
    {
        public List<InventoryInfo.ItemType> itemL;
        public List<int> itemA;
    }
}
