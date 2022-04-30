using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specimen2 : MonoBehaviour
{
    public int level = 1;
    public int xp = 0;
    public int intelligence = 5;
    public int endurance = 5;
    public int strength = 5;
    public int currency = 0;
    public static specimen2 Instance;

    void Start(){
        //LoadPlayer();
    }

    public int getLevel(){
        level = xp / 100 + 1;
        return xp/100 + 1;
    }

    public int setEndurance(int num){
        endurance += num;
        Debug.Log("Specimen's endurance: "+endurance);
        return endurance;
    }

    void Update(){
        if(intelligence < 0){
            intelligence = 0;
        }
        if(strength < 0){
            strength = 0;
        }
        if(endurance < 0){
            endurance = 0;
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            level--;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            endurance++;
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SavePlayer();
        }
    }

    public void SavePlayer(){
        Debug.Log("saved");
        saveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
        Debug.Log("load");
        playerData data = saveSystem.LoadPlayer();
        level = data.level;
        xp = data.xp;
        endurance = data.endurance;
        intelligence = data.intelligence;
        strength = data.strength;
        currency = data.currency;
    }

    // void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         DontDestroyOnLoad(gameObject);
    //         Instance = this;
    //     }
    //     else if (Instance != this)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
