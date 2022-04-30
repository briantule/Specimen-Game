using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState { FreeRoam }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera worldCamera;
    [SerializeField] GameObject levelText;
    [SerializeField] GameObject intelligenceText;
    [SerializeField] GameObject enduranceText;
    [SerializeField] GameObject strengthText;
    [SerializeField] GameObject currencyText;
    [SerializeField] specimen2 specimen;

    GameState state;

    private void Start()
    {
        
    }

    private void Update()
    {
        specimen.LoadPlayer();
        levelText.GetComponent<TextMeshProUGUI>().text = "Level: " + specimen.getLevel();
        intelligenceText.GetComponent<TextMeshProUGUI>().text = "Intelligence: " + specimen.intelligence;
        strengthText.GetComponent<TextMeshProUGUI>().text = "Strength: " + specimen.strength;
        enduranceText.GetComponent<TextMeshProUGUI>().text = "Endurance: " + specimen.endurance;
        currencyText.GetComponent<TextMeshProUGUI>().text = "Currency: " + specimen.currency;
        if (state == GameState.FreeRoam)
        {
            //playerController.HandleUpdate();
        }
    }
}
