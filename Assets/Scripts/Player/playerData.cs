using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class playerData {
    public int level;
    public int xp;
    public int intelligence;
    public int endurance;
    public int strength;
    public int currency;

    public playerData (specimen2 specimen){
        level = specimen.level;
        xp = specimen.xp;
        endurance = specimen.endurance;
        intelligence = specimen.intelligence;
        strength = specimen.strength;
        currency = specimen.currency;
    }
}


