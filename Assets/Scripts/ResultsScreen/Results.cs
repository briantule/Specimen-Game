using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Results
{
    static int XPGained = 0;
    static int intelligenceGained = 0;
    static int strengthGained = 0;
    static int enduranceGained = 0;
    static int currencyGained = 0;
    private static void resetAllStats()
    {
        intelligenceGained = 0;
        strengthGained = 0;
        enduranceGained = 0;
    }
    
    public static void setXPGained(int xp)
    {
        XPGained = xp;
    }

    public static void setIntelligenceGained(int intell)
    {
        resetAllStats();
        intelligenceGained = intell;
    }

    public static void setEnduranceGained(int end)
    {
        resetAllStats();
        enduranceGained = end;
    }

    public static void setStrengthGained(int str)
    {
        resetAllStats();
        strengthGained = str;
    }

    public static void setCurrencyGained(int curr)
    {
        currencyGained = curr;
    }

    public static int getXPGained()
    {
        return XPGained;
    }

    public static int getStrengthGained()
    {
        return strengthGained;
    }

    public static int getEnduranceGained()
    {
        return enduranceGained;
    }

    public static int getIntelligenceGained()
    {
        return intelligenceGained;
    }

    public static int getCurrencyGained()
    {
        return currencyGained;
    }
}
