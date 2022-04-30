using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInfo
{
    public enum ItemType
    {
        XpPotion,
        StrengthPotion,
        IntelligencePotion,
        EndurancePotion,
    }

    public ItemType itemType;
    public int amount;
    


    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.XpPotion: return ItemSprite.Instance.xpPotionSprite;
            case ItemType.StrengthPotion: return ItemSprite.Instance.strengthPotionSprite;
            case ItemType.IntelligencePotion: return ItemSprite.Instance.intelligencePotionSprite;
            case ItemType.EndurancePotion: return ItemSprite.Instance.endurancePotionSprite;

        }
    }
}
