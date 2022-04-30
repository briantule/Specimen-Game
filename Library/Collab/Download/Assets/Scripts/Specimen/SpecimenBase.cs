using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Specimen", menuName = "Specimen/Create new Specimen")]
public class SpecimenBase
{
    [SerializeField] static string name;

    [TextArea]
    [SerializeField] static string description;

    [SerializeField] static string frontSprite;
    [SerializeField] static string backSprite;

    //Base Stats
    //[SerializeField] int lvl;
    [SerializeField] static int exp;
    [SerializeField] static int strength;
    [SerializeField] static int endurance;
    [SerializeField] static int intelligence;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public int Experience
    {
        get
        {
            return exp;
        }
    }

    public int Strength
    {
        get
        {
            return strength;
        }
    }

    public int Endurance
    {
        get
        {
            return endurance;
        }
    }

    public int Intelligence
    {
        get
        {
            return intelligence;
        }
    }
}

public enum SpecimenType
{
    none,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}
