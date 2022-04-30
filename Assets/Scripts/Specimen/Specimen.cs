using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specimen : MonoBehaviour
{
    public SpecimenBase _base;
    static int lvl;
    static int strength;
    static int endurance;
    static int intelligence;

    public Specimen(SpecimenBase sBase, int slvl)
    {
        _base = sBase;
        lvl = slvl;
        strength = Mathf.FloorToInt((_base.Strength * lvl) / 100f) + 5;
        endurance = Mathf.FloorToInt((_base.Endurance * lvl) / 100f) + 5;
        intelligence = Mathf.FloorToInt((_base.Intelligence * lvl) / 100f) + 5;
    }

    public int Strength
    {
        get
        {
            return strength;
        }
        set
        {
            strength = strength + value;
        }
    }
    public int Endurance
    {
        get
        {
            return endurance;
        }
        set
        {
            endurance = endurance + value;
        }
    }
    public int Intelligence
    {
        get
        {
            return intelligence;
        }
        set
        {
            intelligence = intelligence + value;
        }
    }
}
