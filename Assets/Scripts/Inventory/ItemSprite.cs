using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprite : MonoBehaviour
{
    public static ItemSprite Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite xpPotionSprite;
    public Sprite strengthPotionSprite;
    public Sprite intelligencePotionSprite;
    public Sprite endurancePotionSprite;
}
