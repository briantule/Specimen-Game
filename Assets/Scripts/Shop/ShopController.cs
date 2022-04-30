using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;

public class ShopController : MonoBehaviour
{
    //IntelligenceMinigameInfo info;
    [SerializeField] GameObject exitShop;
    [SerializeField] GameObject str;
    [SerializeField] GameObject intl;
    [SerializeField] GameObject end;
    [SerializeField] GameObject xp;
    [SerializeField] GameObject strInv;
    [SerializeField] GameObject intlInv;
    [SerializeField] GameObject endInv;
    [SerializeField] GameObject xpInv;
    [SerializeField] TextMeshProUGUI strAmount;
    [SerializeField] TextMeshProUGUI intAmount;
    [SerializeField] TextMeshProUGUI endAmount;
    [SerializeField] TextMeshProUGUI xpAmount;
    [SerializeField] TextMeshProUGUI currency;
    [SerializeField] specimen2 specimen;
    private InventoryController inventory; // Fardeen - Inventory


    private void Awake()
    {
        str.GetComponent<Button>().onClick.AddListener(OnClickStrength);
        intl.GetComponent<Button>().onClick.AddListener(OnClickIntelligence);
        end.GetComponent<Button>().onClick.AddListener(OnClickEndurance);
        xp.GetComponent<Button>().onClick.AddListener(OnClickXp);        
        strInv.GetComponent<Button>().onClick.AddListener(OnClickSellStrength);
        intlInv.GetComponent<Button>().onClick.AddListener(OnClickSellIntelligence);
        endInv.GetComponent<Button>().onClick.AddListener(OnClickSellEndurance);
        xpInv.GetComponent<Button>().onClick.AddListener(OnClickSellXp);
        exitShop.GetComponent<Button>().onClick.AddListener(OnClickExit);
        inventory = new InventoryController();
        inventory.Load();
        specimen.LoadPlayer();
        strAmount.text = "0";
        intAmount.text = "0";
        endAmount.text = "0";
        xpAmount.text = "0";
        currency.text = specimen.currency.ToString();


        foreach (InventoryInfo inventoryItem in inventory.GetItemList())
        {
            if (inventoryItem.itemType == InventoryInfo.ItemType.StrengthPotion)
            {
                strAmount.text = inventoryItem.amount.ToString();
                continue;
            }
            if (inventoryItem.itemType == InventoryInfo.ItemType.IntelligencePotion)
            {
                intAmount.text = inventoryItem.amount.ToString();
                continue;
            }
            if (inventoryItem.itemType == InventoryInfo.ItemType.EndurancePotion)
            {
                endAmount.text = inventoryItem.amount.ToString();
                continue;
            }
            if (inventoryItem.itemType == InventoryInfo.ItemType.XpPotion)
            {
                xpAmount.text = inventoryItem.amount.ToString();
                continue;
            }
        }
    }

    private void OnClickXp()
    {
        if (specimen.currency >= 10)
        {
            inventory.AddItem(new InventoryInfo { itemType = InventoryInfo.ItemType.XpPotion, amount = 1 });
            foreach (InventoryInfo inventoryItem in inventory.GetItemList())
            {
                if (inventoryItem.itemType == InventoryInfo.ItemType.XpPotion)
                {
                    xpAmount.text = inventoryItem.amount.ToString();
                    break;
                }
            }
            specimen.currency-=10;
            currency.text = specimen.currency.ToString();
            inventory.Save();
        }
        /*Debug.Log("Inventory item " + inventory.GetItemList());*/
    }
    private void OnClickStrength()
    {
        if (specimen.currency >= 10)
        {
            inventory.AddItem(new InventoryInfo { itemType = InventoryInfo.ItemType.StrengthPotion, amount = 1 });
            foreach (InventoryInfo inventoryItem in inventory.GetItemList())
            {
                if (inventoryItem.itemType == InventoryInfo.ItemType.StrengthPotion)
                {
                    strAmount.text = inventoryItem.amount.ToString();
                    break;
                }
            }
            specimen.currency -= 10;
            currency.text = specimen.currency.ToString();
            inventory.Save();
        }
    }
    private void OnClickIntelligence()
    {
        if (specimen.currency >= 10)
        {
            inventory.AddItem(new InventoryInfo { itemType = InventoryInfo.ItemType.IntelligencePotion, amount = 1 });
            foreach (InventoryInfo inventoryItem in inventory.GetItemList())
            {
                if (inventoryItem.itemType == InventoryInfo.ItemType.IntelligencePotion)
                {
                    intAmount.text = inventoryItem.amount.ToString();
                    break;
                }
            }
            specimen.currency -= 10;
            currency.text = specimen.currency.ToString();
            inventory.Save();
        }
    }
    private void OnClickEndurance()
    {
        if (specimen.currency >= 10)
        {
            inventory.AddItem(new InventoryInfo { itemType = InventoryInfo.ItemType.EndurancePotion, amount = 1 });
            foreach (InventoryInfo inventoryItem in inventory.GetItemList())
            {
                if (inventoryItem.itemType == InventoryInfo.ItemType.EndurancePotion)
                {
                    endAmount.text = inventoryItem.amount.ToString();
                    break;
                }
            }
            specimen.currency -= 10;
            currency.text = specimen.currency.ToString();
            inventory.Save();
        }
    }
    private void OnClickSellXp()
    {
        foreach (InventoryInfo inventoryItem in inventory.GetItemList())
        {
            if (inventoryItem.itemType == InventoryInfo.ItemType.XpPotion)
            {
                if (inventoryItem.amount > 0)
                {
                    inventory.RemoveItem(new InventoryInfo { itemType = InventoryInfo.ItemType.XpPotion, amount = 1 });
                    xpAmount.text = inventoryItem.amount.ToString();
                    specimen.currency += 10;
                    currency.text = specimen.currency.ToString();
                }
                else
                {
                    xpAmount.text = "0";
                }
                inventory.Save();
                return;
            }
        }
        xpAmount.text = "0";
        inventory.Save();
    }
    private void OnClickSellStrength()
    {
        foreach (InventoryInfo inventoryItem in inventory.GetItemList())
        {
            if (inventoryItem.itemType == InventoryInfo.ItemType.StrengthPotion)
            {
                if (inventoryItem.amount > 0)
                {
                    inventory.RemoveItem(new InventoryInfo { itemType = InventoryInfo.ItemType.StrengthPotion, amount = 1 });
                    strAmount.text = inventoryItem.amount.ToString();
                    specimen.currency += 10;
                    currency.text = specimen.currency.ToString();
                }
                else
                {
                    strAmount.text = "0";
                }
                inventory.Save();
                return;
            }
        }
        strAmount.text = "0";
        inventory.Save();
    }
    private void OnClickSellIntelligence()
    {
        foreach (InventoryInfo inventoryItem in inventory.GetItemList())
        {
            if (inventoryItem.itemType == InventoryInfo.ItemType.IntelligencePotion)
            {
                if (inventoryItem.amount > 0)
                {
                    inventory.RemoveItem(new InventoryInfo { itemType = InventoryInfo.ItemType.IntelligencePotion, amount = 1 });
                    intAmount.text = inventoryItem.amount.ToString();
                    specimen.currency += 10;
                    currency.text = specimen.currency.ToString();
                }
                else
                {
                    intAmount.text = "0";
                }
                inventory.Save();
                return;
            }
        }
        intAmount.text = "0";
        inventory.Save();
    }
    private void OnClickSellEndurance()
    {
        foreach (InventoryInfo inventoryItem in inventory.GetItemList())
        {
            if (inventoryItem.itemType == InventoryInfo.ItemType.EndurancePotion)
            {
                if (inventoryItem.amount > 0)
                {
                    inventory.RemoveItem(new InventoryInfo{ itemType = InventoryInfo.ItemType.EndurancePotion, amount = 1 });
                    endAmount.text = inventoryItem.amount.ToString();
                    specimen.currency += 10;
                    currency.text = specimen.currency.ToString();
                }
                else
                {
                    endAmount.text = "0";
                }
                inventory.Save();
                return;
            }
        }
        endAmount.text = "0";
        inventory.Save();
    }
    private void OnClickExit()
    {
        specimen.SavePlayer();
        SceneManager.LoadScene("OpenWorld");
    }
    
}
